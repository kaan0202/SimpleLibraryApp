using API.Extensions;
using Application;
using Infrastracture;
using Infrastracture.Filter;
using Infrastracture.Services.Storage.Local.ETicaretAPI.Infrasracture.Services.Storage.Local;
using Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastractureServices();
builder.Services.ConfigurePersistanceServices();
builder.Services.AddStorageService<LocalStorage>();
// Add services to the container.

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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.ConfigureExceptionHandler();

app.MapControllers();

app.Run();
