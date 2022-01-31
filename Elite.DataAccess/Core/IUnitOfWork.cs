using Elite.DataAccess.Core.IRepositories;
using System;

namespace Elite.DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IFeatureRepository Feature { get; }

        IFoodCatRepository FoodCat { get; }

        IFoodItemRepository FoodItem { get; }

        IHotelRepository Hotel { get; }

        IOrderRepository Order { get; }

        IPackageRepository Package { get; }

        IReservationRepository Reservation { get; }

        IRoomRepository Room { get; }

        IRoomStatusRepository RoomStatus { get; }

        IServiceRepository Service { get; }

        ISpecialServiceRepository SpecialService { get; }

        IServiceCatRepository ServiceCat { get; }

        IUserRepository User { get; }

        void Save();
    }
}