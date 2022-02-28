using AutoMapper;
using DomainLayer.Dtos;
using Elite.AppDbContext;

namespace DomainLayer.DomainMapper
{
    public class DomainMapper : Profile
    {
        public DomainMapper()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Hotel, HotelDto>();
            CreateMap<ServiceCat, ServicecatDto>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Service, ServiceDto>();
        }
    }
}