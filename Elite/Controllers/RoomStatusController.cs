using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Mvc;

namespace Elite.Controllers
{
    public class RoomStatusController : BaseController<RoomStatus>
    {
        public RoomStatusController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IActionResult Index()
        {
            var roomStatus = _unitOfWork.RoomStatus.GetAll();
            return View("Index", roomStatus);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var roomStatus = _unitOfWork.RoomStatus.GetById(id);
            if (roomStatus is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Detail",roomStatus);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var isExist = _unitOfWork.RoomStatus.Any(rs => rs.Id == id);

            if (isExist)
            {
                _unitOfWork.RoomStatus.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Upsert(int? id)
        {
            var roomStatus = new RoomStatus();

            if (id == null)
                return View(roomStatus);

            roomStatus = _unitOfWork.RoomStatus.GetById(id);

            if (roomStatus is null)
                return NotFound();

            return View(roomStatus);
        }

        [HttpPost]
        public IActionResult Upsert(RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                if (roomStatus.Id == 0)
                {
                    //New RoomStatus
                    _unitOfWork.RoomStatus.Insert(roomStatus);
                }
                else
                {
                    //Edit RoomStatus
                    _unitOfWork.RoomStatus.Update(roomStatus);
                }
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(roomStatus);
        }
    }
}