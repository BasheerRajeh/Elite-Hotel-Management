using Elite.AppDbContext;
using Elite.AppDbContext.ViewModels;
using Elite.DataAccess.Core;
using Elite.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    [Authorize(Roles = SD.Manager + "," + SD.Admin)]
    public class ServiceCatController : BaseController<ServiceCat>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ServiceCatVM serviceCatVM { get; set; }

        public ServiceCatController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
        {
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ServiceCat.GetById(id);

            string webRootPath = _hostEnvironment.WebRootPath;

            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.ServiceCat.Delete(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.ServiceCat.GetById(id) });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.ServiceCat.GetAll().Include("Category") });
        }

        public IActionResult Upsert(int? id)
        {
            ServiceCatVM serviceCatVM = new ServiceCatVM()
            {
                ServiceCat = new ServiceCat(),
                CategoryList = _unitOfWork.Category.GetCategoryForDropDown()
            };

            if (id != null)
            {
                serviceCatVM.ServiceCat = _unitOfWork.ServiceCat.GetById(id.GetValueOrDefault());
            }

            return View(serviceCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (serviceCatVM.ServiceCat.Id == 0)
                {
                    //New service cat
                    string fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\serviceCat");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    serviceCatVM.ServiceCat.ImageUrl = @"\images\serviceCat\" + fileName + extension;

                    _unitOfWork.ServiceCat.Insert(serviceCatVM.ServiceCat);
                }
                else
                {
                    //Edit service cat
                    var serviceCatFromDb = _unitOfWork.ServiceCat.GetById(serviceCatVM.ServiceCat.Id);

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();

                        var uploads = Path.Combine(webRootPath, @"images\serviceCat");

                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, serviceCatFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        serviceCatVM.ServiceCat.ImageUrl = @"\images\serviceCat\" + fileName + extension_new;
                    }
                    else
                    {
                        serviceCatVM.ServiceCat.ImageUrl = serviceCatFromDb.ImageUrl;
                    }

                    _unitOfWork.ServiceCat.Update(serviceCatVM.ServiceCat);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                serviceCatVM.CategoryList = _unitOfWork.Category.GetCategoryForDropDown();
                return View(serviceCatVM);
            }
        }
    }
}