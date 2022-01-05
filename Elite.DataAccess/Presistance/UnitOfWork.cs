using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Elite.DataAccess.Core.IRepositories;
using Elite.DataAccess.Presistance.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.DataAccess.Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelContext _db;

        public UnitOfWork(HotelContext db)
        {
            this._db = db;
            Category = new CategoryRepository(_db);

            Feature = new FeatureRepository(_db);

            FoodCat = new FoodCatRepository(_db);

            FoodItem = new FoodItemRepository(_db);

            Hotel = new HotelRepository(_db);

            Order = new OrderRepository(_db);

            Package = new PackageRepository(_db);

            Reservation = new ReservationRepository(_db);

            Room = new RoomRepository(_db);

            RoomStatus = new RoomStatusRepository(_db);

            Service = new ServiceRepository(_db);

            SpecialService = new SpecialServiceRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IFeatureRepository Feature { get; private set; }
        public IFoodCatRepository FoodCat { get; private set; }
        public IFoodItemRepository FoodItem { get; private set; }
        public IHotelRepository Hotel { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IPackageRepository Package { get; private set; }
        public IReservationRepository Reservation { get; private set; }
        public IRoomRepository Room { get; private set; }
        public IRoomStatusRepository RoomStatus { get; private set; }
        public IServiceRepository Service { get; private set; }
        public ISpecialServiceRepository SpecialService { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}