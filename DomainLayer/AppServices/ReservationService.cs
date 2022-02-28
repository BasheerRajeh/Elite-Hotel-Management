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
    public class ReservationService : BaseService.BaseService<
        ReservationDto, IReservationRepository, Reservation>
    {
        public ReservationService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork,
                httpContextAccessor)
        {

        }

        public override IReservationRepository DbRepo => UnitOfWork.Reservation;

        public override ReservationDto Create(ReservationDto dto)
        {
            return base.Create(dto);
        }

        public override ReservationDto Update(ReservationDto dto)
        {
            return base.Update(dto);
        }

        public List<ReservationDto> GetAll(Expression<Func<Reservation, bool>> condition = null)
        {
            return Mapper.Map<List<ReservationDto>>(DbRepo.GetAll(condition));
        }

        public void TestMethod()
        {
            GetAll();
        }
    }
}