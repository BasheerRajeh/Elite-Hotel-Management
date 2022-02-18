using AutoMapper;
using Elite.DataAccess.Core;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.BaseService
{
    public abstract class BaseService<Dto, Repo, DbEntity> : IBaseService<Dto, Repo, DbEntity>
        where Dto : class
        where DbEntity : class
        where Repo : IRepository<DbEntity>
    {
        public BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.UnitOfWork = unitOfWork;
            this.HttpContextAccessor = httpContextAccessor;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Repo DbRepo { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public IMapper Mapper
        {
            get
            {
                return (IMapper)HttpContextAccessor?.HttpContext?.RequestServices.GetService(typeof(IMapper));
            }
        }

        public Dto Create(Dto dto)
        {
            DbEntity dbEntity = Mapper.Map<DbEntity>(dto);
            dbEntity = DbRepo.Insert(dbEntity);
            UnitOfWork.Save();
            return Mapper.Map<Dto>(dbEntity);
        }

        public Dto Update(Dto dto)
        {
            DbEntity dbEntity = Mapper.Map<DbEntity>(dto);
            dbEntity = DbRepo.Update(dbEntity);
            UnitOfWork.Save();
            return Mapper.Map<Dto>(dbEntity);
        }
    }
}