using Elite.AppDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IServiceCatRepository : IRepository<ServiceCat>
    {
        IEnumerable<SelectListItem> GetServiceCatForDropDown();
    }
}