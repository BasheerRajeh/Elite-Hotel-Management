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
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly HotelContext _db;

        public LocationRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetLocationForDropDown()
        {
            return _db.Location.Select(i => new SelectListItem()
            {
                Text = i.City,
                Value = i.Id.ToString(),
            });
        }

        public void Update(Location location)
        {
            var objFromDb = _db.Location.FirstOrDefault(s => s.Id == location.Id);
            objFromDb.City = location.City;
            objFromDb.Latitude = location.Latitude;
            objFromDb.Longitude = location.Longitude;

            _db.SaveChanges();
        }
    }
}