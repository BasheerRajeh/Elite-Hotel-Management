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
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly HotelContext _db;

        public HotelRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        /*        public void Update(Hotel hotel)
                {
                    var objFromDb = _db.Hotel.FirstOrDefault(s => s.Id == hotel.Id);
                    objFromDb.Name = hotel.Name;
                    objFromDb.City = hotel.City;
                    objFromDb.ImageUrl = hotel.ImageUrl;

                    _db.SaveChanges();
                }
        */
    }
}