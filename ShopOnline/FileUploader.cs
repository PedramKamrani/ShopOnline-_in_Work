using _0_FrameWork.Application;
using _0_FramWork.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ShopOnline
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file, string path)
        {
            if (file == null) return "";

            var directory = $"{_webHostEnvironment.WebRootPath}//ProductPicture{path}";
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filepath = $"{directory}//{fileName}";
            using var output = File.Create(filepath);
            file.CopyTo(output);
            return $"{path}//{fileName}";
        }
    }
}
