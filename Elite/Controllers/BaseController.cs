using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elite.Controllers
{
    public abstract class BaseController<T> : Controller where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public abstract IActionResult Upsert(int? id);

        #region API CALLS

        [HttpGet]
        public abstract IActionResult GetAll();

        [HttpDelete]
        public abstract IActionResult Delete(int id);

        [HttpGet]
        public abstract IActionResult Details(int id);

        #endregion API CALLS
    }
}