using CrudApplication.Data;
using CrudApplication.Models;
using CrudApplication.Models.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class UploadController : Controller
    {
        private readonly ApplicationContext context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public UploadController(ApplicationContext context, IWebHostEnvironment hostingEnvironment)
        {
            this.context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadImage(ImageCreateModel imageCreateModel)
        {
            if (ModelState.IsValid)
            {
                var path = hostingEnvironment.WebRootPath;
                var filePath = "/Content/Image/" + imageCreateModel.ImagePath.FileName;
                var fullPath = Path.Combine(path + filePath);  //path + filePath;
                UploadFile(imageCreateModel.ImagePath, fullPath);

                var data = new Image()
                {
                    Name = imageCreateModel.Name,
                    ImagePath = filePath
                };

                context.Images.Add(data);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public void UploadFile(IFormFile file, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
        }

        public IActionResult Index()
        {
            var data = context.Images.ToList();
            return View(data);
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
