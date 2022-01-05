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
    public class RoomStatusRepository : Repository<RoomStatus>, IRoomStatusRepository
    {
        private readonly HotelContext _db;

        public RoomStatusRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetRoomStatusForDropDown()
        {
            return _db.RoomStatus.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }

        public void Update(RoomStatus roomStatus)
        {
            var objFromDb = _db.RoomStatus.FirstOrDefault(s => s.Id == roomStatus.Id);
            objFromDb.Name = roomStatus.Name;
            objFromDb.Value = roomStatus.Value;

            _db.SaveChanges();
        }
    }
}