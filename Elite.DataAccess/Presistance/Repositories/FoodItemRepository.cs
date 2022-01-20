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
    public class FoodItemRepository : Repository<FoodItem>, IFoodItemRepository
    {
        private readonly HotelContext _db;

        public FoodItemRepository(HotelContext db) : base(db)
        {
            _db = db;
        }
    }
}