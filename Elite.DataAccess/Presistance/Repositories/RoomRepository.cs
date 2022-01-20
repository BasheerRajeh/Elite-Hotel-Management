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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly HotelContext _db;

        public RoomRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        /*        public void Update(Room room)
                {
                    var objFromDb = _db.Room.FirstOrDefault(s => s.Id == room.Id);
                    objFromDb.Num = room.Num;
                    objFromDb.HotelId = room.HotelId;
                    objFromDb.CategoryId = room.CategoryId;
                    objFromDb.RoomStatusId = room.RoomStatusId;
                    objFromDb.ImageUrl = room.ImageUrl;
                    objFromDb.Package = room.Package;
                    _db.SaveChanges();
                }
        */
    }
}