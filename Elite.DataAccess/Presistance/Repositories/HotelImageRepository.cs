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
    public class HotelImageRepository : Repository<HotelImage>, IHotelImageRepository
    {
        private readonly HotelContext _db;

        public HotelImageRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public void Update(HotelImage hotelImage)
        {
            var objFromDb = _db.HotelImage.FirstOrDefault(s => s.Id == hotelImage.Id);
            objFromDb.HotelId = hotelImage.HotelId;
            objFromDb.FileName = hotelImage.FileName;

            _db.SaveChanges();
        }
    }
}