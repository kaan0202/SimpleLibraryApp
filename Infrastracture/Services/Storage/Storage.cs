﻿using Application.Abstraction.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Services.Storage
{
    public class Storage
    {
        protected async Task<string> FileRenameAsync(string fileName)
        {
            string newFileName = await Task.Run<string>(async () =>
            {

                Guid guid = Guid.NewGuid();
                string newName = guid.ToString();
                string extension = Path.GetExtension(fileName);
                //string newFileName = $"{NameOperation.CharacterRegulatory(newName)}{extension}";
                string newFileName = $"{newName}{extension}";

                return newFileName;
            });

            return newFileName;

        }
        

    }
}
