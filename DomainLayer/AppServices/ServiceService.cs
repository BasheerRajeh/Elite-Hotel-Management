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
    class ServiceService : BaseService.BaseService<
        ServiceDto, IServiceRepository, Service>
    {
        public ServiceService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork,
                httpContextAccessor)
        {

        }

        public override IServiceRepository DbRepo => UnitOfWork.Service;

        public override ServiceDto Create(ServiceDto dto)
        {
            return base.Create(dto);
        }

        public override ServiceDto Update(ServiceDto dto)
        {
            return base.Update(dto);
        }

        public List<ServiceDto> GetAll(Expression<Func<Service, bool>> condition = null)
        {
            return Mapper.Map<List<ServiceDto>>(DbRepo.GetAll(condition));
        }

        public void TestMethod()
        {
            GetAll();
        }
    }
}