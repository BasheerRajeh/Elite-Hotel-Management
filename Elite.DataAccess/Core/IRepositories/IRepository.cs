using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Elite.DataAccess.Core.IRepositories
{
    public interface IRepository<DbModel> where DbModel : class
    {
        #region oldcode

        /*        T Get(object id);

                IEnumerable<T> GetAll(
                    Expression<Func<T, bool>> filter = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = null
                    );

                T GetFirstOrDefault(
                    Expression<Func<T, bool>> filter = null,
                    string includeProperties = null
                    );

                void Add(T entity);

                void Remove(object id);

                void Remove(T entity);
        */

        #endregion oldcode

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