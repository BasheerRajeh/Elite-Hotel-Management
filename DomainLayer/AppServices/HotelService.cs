using DomainLayer.Dtos;
using Elite.AppDbContext;
using Elite.DataAccess.Core;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DomainLayer.AppServices
{
    public class HotelService : BaseService.BaseService<
        HotelDto, IHotelRepository, Hotel>
    {
        public HotelService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork,
                httpContextAccessor)
        {

        }

        public override IHotelRepository DbRepo => UnitOfWork.Hotel;

        public override HotelDto Create(HotelDto dto)
        {
            return base.Create(dto);
        }

        public override HotelDto Update(HotelDto dto)
        {
            return base.Update(dto);
        }

        public List<HotelDto> GetAll(Expression<Func<Hotel, bool>> condition = null)
        {
            return Mapper.Map<List<HotelDto>>(DbRepo.GetAll(condition));
        }

    }
}
