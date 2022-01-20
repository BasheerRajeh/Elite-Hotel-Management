using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class FoodCatRepository : Repository<FoodCat>, IFoodCatRepository
    {
        private readonly HotelContext _db;

        public FoodCatRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetFoodCatForDropDown()
        {
            return _db.FoodCat.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }
    }
}