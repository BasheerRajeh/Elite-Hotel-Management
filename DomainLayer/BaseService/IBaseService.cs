using AutoMapper;
using Elite.DataAccess.Core;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.AspNetCore.Http;

namespace DomainLayer.BaseService
{
    public interface IBaseService<Dto, Repo, DbEntity>
        where Dto : class
        where Repo : IRepository<DbEntity>
        where DbEntity : class
    {
        public IUnitOfWork UnitOfWork { get; }

        public abstract Repo DbRepo { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }

        public IMapper Mapper { get; }

        public abstract Dto Create(Dto dto);

        public abstract Dto Update(Dto dto);
    }
}