using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiMailIdentity.Controllers
{
    public class UploadsController : Controller
    {
        private readonly IHostingEnvironment _env;
        public UploadsController(IHostingEnvironment env)
        {
            _env = env;
        }
        [HttpPost]
        public IActionResult CKEasyImage(IFormFile file)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            string uniqueFileName = "";
            uniqueFileName = file.FileName;
            uniqueFileName = string.Format("{0}_{1}_{2}", DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.Ticks, uniqueFileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok(uniqueFileName);
        }
    }
}
