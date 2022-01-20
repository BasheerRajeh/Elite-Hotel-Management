using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IRepository<DbModel> where DbModel : class
    {
        DbModel GetById(object id);

        bool IsExist(object id);

        IQueryable<DbModel> GetAll(Expression<Func<DbModel, bool>> condition = null);

        DbModel Insert(DbModel newObj);

        bool Any(Expression<Func<DbModel, bool>> query);

        bool Any();

        DbModel Update(DbModel newObj);

        void DeleteAll(Expression<Func<DbModel, bool>> condition = null);

        void Delete(object id);

        void Delete(DbModel obj);

        int GetTotalCounts(Expression<Func<DbModel, bool>> condition = null);
    }
}