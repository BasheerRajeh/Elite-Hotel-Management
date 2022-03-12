using System;
using System.IO;
using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Elite.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Elite.Controllers
{
    [Authorize(Roles = SD.Manager + "," + SD.Admin)]
    public class ReservationController : BaseController<Reservation>
    {
        public ReservationController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
        public IActionResult Upsert(int? id)
        {
            var reservation = new Reservation();

            if (id == null) return View(reservation);

            reservation = _unitOfWork.Reservation.GetById(id);

            if (reservation == null) return NotFound();

            return View(reservation);
        }
        */

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (reservation.Id == 0)
                {
                    //New reservation
                    var fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\categories");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams =
                        new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    reservation.ImageUrl = @"\images\categories\" + fileName + extension;

                    _unitOfWork.Reservation.Insert(reservation);
                }
                else
                {
                    //Edit reservation
                    var reservationFromDb = _unitOfWork.Reservation.GetById(reservation.Id);

                    if (files.Count > 0)
                    {
                        var fileName = Guid.NewGuid().ToString();

                        var uploads = Path.Combine(webRootPath, @"images\categories");

                        var extensionNew = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, reservationFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extensionNew),
                            FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        reservation.ImageUrl = @"\images\categories\" + fileName + extensionNew;
                    }
                    else
                    {
                        reservation.ImageUrl = reservationFromDb.ImageUrl;
                    }

                    _unitOfWork.Reservation.Update(reservation);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(reservation);
        }
        */

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Reservation.GetAll() });
        }

        /*
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Reservation.GetById(id);

            string webRootPath = _hostEnvironment.WebRootPath;

            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            if (objFromDb == null) return Json(new { success = false, message = "Error while deleting." });

            _unitOfWork.Reservation.Delete(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }
        */

        [HttpGet]
        public IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.Reservation.GetById(id) });
        }

        #endregion API CALLS
    }
}