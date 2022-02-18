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
        }
    }
}