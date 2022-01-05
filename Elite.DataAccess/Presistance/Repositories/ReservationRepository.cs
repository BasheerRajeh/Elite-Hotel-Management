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
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly HotelContext _db;

        public ReservationRepository(HotelContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Reservation reservation)
        {
            var objFromDb = _db.Reservation.FirstOrDefault(s => s.Id == reservation.Id);
            objFromDb.ReservationNum = reservation.ReservationNum;
            objFromDb.RequestStatusId = reservation.RequestStatusId;
            objFromDb.CustomerId = reservation.CustomerId;
            objFromDb.RoomId = reservation.RoomId;
            objFromDb.Checkout = reservation.Checkout;
            objFromDb.RequestDate = reservation.RequestDate;
            objFromDb.StartDate = reservation.StartDate;
            objFromDb.EndDate = reservation.EndDate;

            _db.SaveChanges();
        }
    }
}