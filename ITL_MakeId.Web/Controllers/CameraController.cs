using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ITL_MakeId.Data;
using ITL_MakeId.Model.DomainModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITL_MakeId.Web.Controllers
{
    public class CameraController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _environment;
        public CameraController(IHostingEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _environment = hostingEnvironment;
            _context = context;
        }

        [HttpGet]
        public IActionResult Capture()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Capture(int id)
        {
            IdentityCard model = new IdentityCard();

            model = _context.IdentityCards.Find(id);

            //model = await _context.IdentityCards.Include(c => c.BloodGroup)
            //    .Include(c => c.Designation)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            try
            {
                var files = HttpContext.Request.Form.Files;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            // Getting Filename
                            var fileName = file.FileName;
                            // Unique filename "Guid"
                            var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                            // Getting Extension
                            var fileExtension = Path.GetExtension(fileName);
                            // Concating filename + fileExtension (unique filename)
                            var newFileName = string.Concat(myUniqueFileName, fileExtension);
                            //  Generating Path to store photo 
                            var filepath = Path.Combine(_environment.WebRootPath, "image/user/") + $@"\{newFileName}";

                            if (!string.IsNullOrEmpty(filepath))
                            {
                                // Storing Image in Folder
                                StoreInFolder(file, filepath);
                            }

                            model.ImagePathOfUser = newFileName;
                            _context.Update(model);
                            //_context.IdentityCards.Update(imageStore);
                            _context.SaveChanges();


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

        /// <summary>
        /// Saving captured image into Folder.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        /// <summary>
        /// Saving captured image into database.
        /// </summary>
        /// <param name="imageBytes"></param>
        //private void StoreInDatabase(byte[] imageBytes)
        //{
        //    try
        //    {
        //        if (imageBytes != null)
        //        {
        //            string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
        //            string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

        //            ImageStore imageStore = new ImageStore()
        //            {
        //                CreateDate = DateTime.Now,
        //                ImageBase64String = imageUrl,
        //                ImageId = 0
        //            };

        //            _context.ImageStore.Add(imageStore);
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        }
    }


