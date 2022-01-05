using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    public class LocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Location location = new Location();

            if (id == null)
            {
                return View(location);
            }

            location = _unitOfWork.Location.Get(id);

            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Location location)
        {
            if (ModelState.IsValid)
            {
                if (location.Id == 0)
                {
                    _unitOfWork.Location.Add(location);
                }
                else
                {
                    _unitOfWork.Location.Update(location);
                }

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(location);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Location.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Location.Get(id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _unitOfWork.Location.Remove(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        #endregion API CALLS
    }
}