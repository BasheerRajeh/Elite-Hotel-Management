﻿using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly HotelContext _db;

        public CategoryRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryForDropDown()
        {
            return _db.Category.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        /*        public void Update(Category category)
                {
                    var objFromDb = _db.Category.FirstOrDefault(s => s.Id == category.Id);
                    objFromDb.Name = category.Name;
                    objFromDb.MaxCap = category.MaxCap;
                    objFromDb.PricePerNight = category.PricePerNight;
                    objFromDb.ImageUrl = category.ImageUrl;

                    _db.SaveChanges();
                }
        */
    }
}