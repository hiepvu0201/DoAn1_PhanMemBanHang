using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadImageController: Controller
    {
        private readonly IImageHelper _imageHelper;

        public UploadImageController(IImageHelper imageHelper)
        {
            _imageHelper = imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var url = await _imageHelper.UploadImage(file);
            return Json(new { location = url });
        }
    }
}
