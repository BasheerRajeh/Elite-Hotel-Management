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
    public class ServiceCatService : BaseService.BaseService<
        ServicecatDto, IServiceCatRepository, ServiceCat>
    {
        public ServiceCatService(IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor) : base(unitOfWork,
                httpContextAccessor)
        {

        }

        public override IServiceCatRepository DbRepo => UnitOfWork.ServiceCat;

        public override ServicecatDto Create(ServicecatDto dto)
        {
            return base.Create(dto);
        }

        public override ServicecatDto Update(ServicecatDto dto)
        {
            return base.Update(dto);
        }

        public List<ServicecatDto> GetAll(Expression<Func<ServiceCat, bool>> condition = null)
        {
            return Mapper.Map<List<ServicecatDto>>(DbRepo.GetAll(condition));
        }

        public void TestMethod()
        {
            GetAll();
        }
    }
}
