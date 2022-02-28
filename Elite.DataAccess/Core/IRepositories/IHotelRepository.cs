using Elite.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        IEnumerable<SelectListItem> GetCategoryForDropDown();
        object GetAll(Expression<Func<Category, bool>> condition);
    }
}