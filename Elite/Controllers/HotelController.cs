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
    public class HotelController : BaseController<Hotel>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public HotelController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
        {
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Hotel hotel = new Hotel();

            if (id == null)
            {
                return View(hotel);
            }

            hotel = _unitOfWork.Hotel.GetById(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (hotel.Id == 0)
                {
                    //New Hotel
                    string fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\hotels");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    hotel.ImageUrl = @"\images\hotels\" + fileName + extension;

                    _unitOfWork.Hotel.Insert(hotel);
                }
                else
                {
                    //Edit Hotel
                    var hotelFromDb = _unitOfWork.Hotel.GetById(hotel.Id);

                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();

                        var uploads = Path.Combine(webRootPath, @"images\hotels");

                        var extension_new = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, hotelFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension_new), FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        hotel.ImageUrl = @"\images\hotels\" + fileName + extension_new;
                    }
                    else
                    {
                        hotel.ImageUrl = hotelFromDb.ImageUrl;
                    }

                    _unitOfWork.Hotel.Update(hotel);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(hotel);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Hotel.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Hotel.GetById(id);

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

            _unitOfWork.Hotel.Delete(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.Hotel.GetById(id) });
        }

        #endregion API CALLS
    }
}