using DomainLayer.AppServices;
using Elite.DataAccess.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Pool
{
    public class ServicePool : IServicePool
    {

        public CategoryService CategoryService { get; }
        public HotelService HotelService { get; }
        public ReservationService ReservationService { get; }
        public ServiceService ServiceService { get; }
        public ServiceCatService ServiceCatService { get; }
        public ServicePool(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            CategoryService = new CategoryService(unitOfWork, httpContextAccessor);
            HotelService = new HotelService(unitOfWork, httpContextAccessor);
            ReservationService = new ReservationService(unitOfWork, httpContextAccessor);
            ServiceService = new ServiceService(unitOfWork, httpContextAccessor);
            ServiceCatService = new ServiceCatService(unitOfWork, httpContextAccessor);
        }
    }
}
