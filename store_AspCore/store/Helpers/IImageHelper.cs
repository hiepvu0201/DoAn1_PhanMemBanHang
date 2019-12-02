using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImage(IFormFile file);
    }
}
