using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class ServiceCatRepository : Repository<ServiceCat>, IServiceCatRepository
    {
        private readonly HotelContext _db;

        public ServiceCatRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetServiceCatForDropDown()
        {
            return _db.ServiceCat.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }
    }
}