using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    public class ServiceCatController : BaseController<ServiceCat>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ServiceCatController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
        {
            this._hostEnvironment = hostEnvironment;
        }

        [HttpDelete]
        public override IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.ServiceCat.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.ServiceCat.Remove(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        [HttpGet]
        public override IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.ServiceCat.Get(id) });
        }

        [HttpGet]
        public override IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.ServiceCat.GetAll() });
        }

        public override IActionResult Upsert(int? id)
        {
            ServiceCat serviceCat = new ServiceCat();

            if (id == null)
            {
                return View(serviceCat);
            }

            serviceCat = _unitOfWork.ServiceCat.Get(id);

            if (serviceCat == null)
            {
                return NotFound();
            }

            return View(serviceCat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Upsert(ServiceCat serviceCat)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (serviceCat.Id == 0)
                {
                    //New Hotel
                    string fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\serviceCat");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    serviceCat.ImageUrl = @"\images\serviceCat\" + fileName + extension;

                    _unitOfWork.ServiceCat.Add(serviceCat);
                }
                else
                {
                    //Edit Hotel
                    var serviceCatFromDb = _unitOfWork.ServiceCat.Get(serviceCat.Id);

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

                        serviceCat.ImageUrl = @"\images\serviceCat\" + fileName + extension_new;
                    }
                    else
                    {
                        serviceCat.ImageUrl = serviceCatFromDb.ImageUrl;
                    }

                    _unitOfWork.ServiceCat.Update(serviceCat);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(serviceCat);
            }
        }
    }
}