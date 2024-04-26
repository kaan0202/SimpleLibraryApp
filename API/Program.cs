using API.Extensions;
using Application;
using Infrasracture.Services.Storage.Local;
using Infrastracture;
using Infrastracture.Filter;
using Infrastracture.Services.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Persistance;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL.ColumnWriters;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastractureServices();
builder.Services.ConfigurePersistanceServices();
builder.Services.AddAdminAuthenticationOption(builder.Configuration);
builder.Services.AddStorageService<LocalStorage>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));


Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true, columnOptions: new Dictionary<string, ColumnWriterBase>
    {
     { "message", new RenderedMessageColumnWriter()},
     { "message_template", new MessageTemplateColumnWriter() },
     {"level", new LevelColumnWriter() },
     {"time_stamp", new TimestampColumnWriter() },
     {"exception", new ExceptionColumnWriter() },
     {"log_event", new LogEventSerializedColumnWriter()}

    })
    .Enrich.FromLogContext()
    .WriteTo.Seq("http://localhost:5341/")
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);
// Add services to the container.


builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateFilter>();
}).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.Name != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();

});
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseHttpLogging();
app.UseAuthorization();
app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
