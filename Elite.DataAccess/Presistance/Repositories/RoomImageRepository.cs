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
    public class RoomImageRepository : Repository<RoomImage>, IRoomImageRepository
    {
        private readonly HotelContext _db;

        public RoomImageRepository(HotelContext db) : base(db)
        {
            _db = db;
        }


        public void Update(RoomImage roomImage)
        {
            var objFromDb = _db.RoomImage.FirstOrDefault(s => s.Id == roomImage.Id);
            objFromDb.RoomId = roomImage.RoomId;
            objFromDb.FileName = roomImage.FileName;

            _db.SaveChanges();
        }
    }
}