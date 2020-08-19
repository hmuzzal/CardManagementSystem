using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ITL_MakeId.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITL_MakeId.Web.Controllers
{
    public class CameraController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _webHostEnvironment;
        public CameraController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _webHostEnvironment = hostingEnvironment;
            _context = context;
        }

        [HttpGet]
        public IActionResult Capture()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Capture(string name)
        {
            try
            {
                string uniqueFileName = null;
                string filePath = null;
                var files = HttpContext.Request.Form.Files;
                
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            // Getting Filename
                            var fileName = file.FileName;

                            string uplaodsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "image/user/");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                            filePath = Path.Combine(uplaodsFolder, uniqueFileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                //viewModel.ImagePathOfUser.CopyTo(stream);
                            }


                        }
                    }
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                throw;
            }



        }

        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }


        private void StoreInDatabase(byte[] imageBytes)
        {
            try
            {
                if (imageBytes != null)
                {
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                    //ImageStore imageStore = new ImageStore()
                    //{
                    //    CreateDate = DateTime.Now,
                    //    ImageBase64String = imageUrl,
                    //    ImageId = 0
                    //};

                    //_context.ImageStore.Add(imageStore);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
