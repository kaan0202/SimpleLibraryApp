using Application.Abstraction.Storage;
using Application.Abstraction.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    namespace Infrasracture.Services.Storage.Local
    {
        public class LocalStorage : Infrastracture.Services.Storage.Storage, ILocalStorage
        {
            readonly IWebHostEnvironment _webHostEnvironment;
            public LocalStorage(IWebHostEnvironment webHostEnvironment)
            {
                _webHostEnvironment = webHostEnvironment;
            }

            public async Task DeleteAsync(string path, string fileName)
             => File.Delete($"{path}\\{fileName}");

            public List<string> GetFiles(string path)
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                return directory.GetFiles().Select(f => f.Name).ToList();
            }

            public bool HasFile(string path, string fileName)
             => File.Exists($"{path}\\{fileName}");
            public async Task<bool> CopyFileAsync(string path, IFormFile file)
            {
                try
                {
                    await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }

            

            async Task<List<(string fileName, string pathOrContainerName)>> IStorage.UploadAsync(string pathOrContainerName, IFormFileCollection files)
            {
                string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathOrContainerName);
                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                List<(string fileName, string path)> datas = new();
                List<bool> results = new();

                foreach (var file in files)
                {


                    string newFileName = await FileRenameAsync(file.Name);
                    bool result = await CopyFileAsync($"{uploadPath}\\{newFileName}", file);
                    datas.Add((file.Name, $"{pathOrContainerName}\\{newFileName}"));
                    results.Add(result);
                }
                if (results.TrueForAll(r => r.Equals(true)))
                    return datas;
                throw new Exception("Hata");

                //exception oluşturulacak
            }
        }
    }




