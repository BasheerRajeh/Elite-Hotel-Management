using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elite.Utility;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly HotelContext _db;

        public ReservationRepository(HotelContext db) : base(db)
        {
            _db = db;
        }


        public void Serve(int id)
        {
            var reservation = _db.Reservation.FirstOrDefault(r => r.Id == id);
            if (reservation != null) reservation.RequestStatusId = SD.Served;
            _db.SaveChanges();
        }
        
        public void Reject(int id)
        {
            var reservation = _db.Reservation.FirstOrDefault(r => r.Id == id);
            if (reservation != null) reservation.RequestStatusId = SD.Rejected;
            _db.SaveChanges();
        }
        
    }
}