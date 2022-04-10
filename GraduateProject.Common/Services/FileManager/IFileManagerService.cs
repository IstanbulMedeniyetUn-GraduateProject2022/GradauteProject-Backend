using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.FileManager
{
    public interface IFileManagerService : IDisposable
    {
        public Task<string> UploadFileAsync(IFormFile file,
            string referenceType,
            bool generateRandomFileName = false);


        public Task DeleteFileAsync(string url);
    }
}