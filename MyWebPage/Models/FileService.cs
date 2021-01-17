using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MimeTypes;

namespace MyWebPage.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public FileStreamResult GetFileAsStream(String filePath)
        {
            try
            {
                string wwwPath = _environment.WebRootPath;
                string fullPath = Path.Combine(wwwPath, filePath);
                if (File.Exists(fullPath))
                {
                    var stream = _environment.WebRootFileProvider
                                                    .GetFileInfo(filePath)
                                                    .CreateReadStream();

                    return new FileStreamResult(stream, MimeTypeMap.GetMimeType(fullPath)) { FileDownloadName = Path.GetFileName(filePath) };
                }
                else
                {
                    return null;
                }

                
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            

            


        }
    }
}
