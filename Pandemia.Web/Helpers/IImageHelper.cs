using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
        string UploadImage(byte[] pictureArray, string folder);
        Task<string> UploadImageProfileAsync(IFormFile imageProfile, string folder);
        string UploadImageProfileAsync(byte[] pictureProfileArray, string folder);

    }
}
