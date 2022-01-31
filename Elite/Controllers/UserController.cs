using Elite.DataAccess.Core;
using Elite.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    [Authorize(Roles = SD.Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var items = _unitOfWork.User.GetAll(u => u.Id != claims.Value).AsEnumerable();

            return View(items);
        }

        public IActionResult Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.User.LockUser(id);
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.User.UnLockUser(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}