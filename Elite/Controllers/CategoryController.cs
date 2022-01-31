using System;
using System.IO;
using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Elite.Controllers
{
    [Authorize]
    public class CategoryController : BaseController<Category>
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) : base(unitOfWork)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            var category = new Category();

            if (id == null) return View(category);

            category = _unitOfWork.Category.GetById(id);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                var webRootPath = _hostEnvironment.WebRootPath;

                var files = HttpContext.Request.Form.Files;

                if (category.Id == 0)
                {
                    //New category
                    var fileName = Guid.NewGuid().ToString();

                    var uploads = Path.Combine(webRootPath, @"images\categories");

                    var extension = Path.GetExtension(files[0].FileName);

                    using (var fileStreams =
                        new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStreams);
                    }

                    category.ImageUrl = @"\images\categories\" + fileName + extension;

                    _unitOfWork.Category.Insert(category);
                }
                else
                {
                    //Edit category
                    var categoryFromDb = _unitOfWork.Category.GetById(category.Id);

                    if (files.Count > 0)
                    {
                        var fileName = Guid.NewGuid().ToString();

                        var uploads = Path.Combine(webRootPath, @"images\categories");

                        var extensionNew = Path.GetExtension(files[0].FileName);

                        var imagePath = Path.Combine(webRootPath, categoryFromDb.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(imagePath)) System.IO.File.Delete(imagePath);

                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extensionNew),
                            FileMode.Create))
                        {
                            files[0].CopyTo(fileStreams);
                        }

                        category.ImageUrl = @"\images\categories\" + fileName + extensionNew;
                    }
                    else
                    {
                        category.ImageUrl = categoryFromDb.ImageUrl;
                    }

                    _unitOfWork.Category.Update(category);
                }

                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.GetById(id);

            string webRootPath = _hostEnvironment.WebRootPath;

            var imagePath = Path.Combine(webRootPath, objFromDb.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            if (objFromDb == null) return Json(new { success = false, message = "Error while deleting." });

            _unitOfWork.Category.Delete(objFromDb);

            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully." });
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return Json(new { data = _unitOfWork.Category.GetById(id) });
        }

        #endregion API CALLS
    }
}