using Application.Abstraction.Storage;
using Application.Abstraction.Storage.Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Services.Storage.Azure
{
   

        public class AzureStorage : Storage, IStorage
        {
            readonly BlobServiceClient _blobServiceClient;
            BlobContainerClient _blobContainerClient;

            public AzureStorage(IConfiguration configuration)
            {
                _blobServiceClient = new(configuration["Storage:Azure"]);
            }

          

            public async Task DeleteAsync(string containerName, string fileName)
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
                await blobClient.DeleteAsync();

            }

            public List<string> GetFiles(string pathOrContainerName)
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
                return _blobContainerClient.GetBlobs().Select(x => x.Name).ToList();
            }

            public bool HasFile(string pathOrContainerName, string fileName)
            {
                _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
                return _blobContainerClient.GetBlobs().Any(b => b.Name == fileName);
            }

       

        async Task<List<(string fileName, string pathOrContainerName)>> IStorage.UploadAsync(string pathOrContainerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(pathOrContainerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            List<(string fileName, string containerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(file.Name);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(newFileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((newFileName, $"{pathOrContainerName}/{newFileName}"));
            }
            return datas;
        }
    }
    }

