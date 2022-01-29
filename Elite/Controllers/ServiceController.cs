using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using Elite.AppDbContext.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Elite.Controllers
{
    public class ServiceController : BaseController<Service>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty]
        public ServiceVM serviceVM { get; set; }

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
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
            var objFromDb = _unitOfWork.Service.GetById(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Service.Delete(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.Service.GetById(id) });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Service.GetAll().Include("ServiceCat") });//().Include(e => e.ServiceCat)
        }

        public IActionResult Upsert(int? id)
        {
            ServiceVM serviceVM = new ServiceVM()
            {
                Service = new Service(),
                ServiceCatList = _unitOfWork.ServiceCat.GetServiceCatForDropDown()
            };

            if (id != null)
            {
                serviceVM.Service = _unitOfWork.Service.GetById(id.GetValueOrDefault());
            }

            return View(serviceVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (serviceVM.Service.Id == 0)
                {
                    //New service cat
                    string fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\service");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    serviceVM.Service.ImageUrl = @"\images\service\" + fileName + extension;

                    _unitOfWork.Service.Insert(serviceVM.Service);
                }
                else
                {
                    //Edit service cat
                    var serviceFromDb = _unitOfWork.Service.GetById(serviceVM.Service.Id);

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();

                        var uploads = Path.Combine(webRootPath, @"images\service");

                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, serviceFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        serviceVM.Service.ImageUrl = @"\images\service\" + fileName + extension_new;
                    }
                    else
                    {
                        serviceVM.Service.ImageUrl = serviceFromDb.ImageUrl;
                    }

                    _unitOfWork.Service.Update(serviceVM.Service);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                serviceVM.ServiceCatList = _unitOfWork.ServiceCat.GetServiceCatForDropDown();
                return View(serviceVM);
            }
        }
    }
}