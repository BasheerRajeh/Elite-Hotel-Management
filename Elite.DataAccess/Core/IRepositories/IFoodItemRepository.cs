using Elite.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IFoodItemRepository : IRepository<FoodItem>
    {
        void Update(FoodItem foodItem);
    }
}