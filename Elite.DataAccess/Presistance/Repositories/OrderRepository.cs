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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly HotelContext _db;

        public OrderRepository(HotelContext db) : base(db)
        {
            _db = db;
        }

        /*    public void Update(Order order)
                {
                    var objFromDb = _db.Order.FirstOrDefault(s => s.Id == order.Id);
                    objFromDb.OrderNum = order.OrderNum;
                    objFromDb.ReservationId = order.ReservationId;
                    objFromDb.FoodItemId = order.FoodItemId;
                    objFromDb.Time = order.Time;
                    objFromDb.Quantity = order.Quantity;

                    _db.SaveChanges();
                }
        */
    }
}