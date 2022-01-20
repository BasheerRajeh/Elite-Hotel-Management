using Elite.AppDbContext;
using Elite.DataAccess.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Elite.DataAccess.Presistance.Repositories
{
    public class Repository<DbModel> : IRepository<DbModel> where DbModel : class
    {
        #region oldcode

        /*        protected readonly DbContext Context;

                protected DbSet<T> dbSet;

                public Repository(DbContext context)
                {
                    this.Context = context;
                    this.dbSet = context.Set<T>();
                }

                public virtual void Add(T entity)
                {
                    dbSet.Add(entity);
                }

                public virtual T Get(object id)
                {
                    return dbSet.Find(id);
                }

                public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
                {
                    IQueryable<T> query = dbSet;

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    if (includeProperties != null)
                    {
                        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(includeProperty);
                        }
                    }

                    if (orderBy != null)
                    {
                        return orderBy(query).ToList();
                    }

                    return query.ToList();
                }

                public virtual T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
                {
                    IQueryable<T> query = dbSet;

                    if (filter != null)
                    {
                        query = query.Where(filter);
                    }

                    if (includeProperties != null)
                    {
                        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(includeProperty);
                        }
                    }

                    return query.FirstOrDefault();
                }

                public virtual void Remove(object id)
                {
                    T entityToRemove = dbSet.Find(id);

                    Remove(entityToRemove);
                }

                public virtual void Remove(T entity)
                {
                    dbSet.Remove(entity);
                }
        */

        #endregion oldcode

        protected DbContext _db { get; set; }

        private DbSet<DbModel> _dbSet { get; set; }

        private IQueryable<DbModel> _dbQueryable;

        public Repository(DbContext db)
        {
            this._db = db;
            _dbSet = _db?.Set<DbModel>();
            _dbSet.Load();
        }

        protected IQueryable<DbModel> DBQueryable
        {
            get
            {
                if (_dbQueryable == null)
                {
                    _dbQueryable = _dbSet.AsQueryable();
                }
                return this._dbQueryable;
            }
        }

        public bool Any()
        {
            return DBQueryable.Any();
        }

        public bool Any(Expression<Func<DbModel, bool>> query)
        {
            return Any() ? DBQueryable.Any(query) : false;
        }

        public DbModel GetById(object id)
        {
            if (id == null)
                return null;
            Int64 idAsReal = -1;
            bool isIdParseable = Int64.TryParse(id.ToString(), out idAsReal);
            IProperty key = _db.Model.FindEntityType(typeof(DbModel)).FindPrimaryKey().Properties[0];
            DbModel dbClass = null;
            if (isIdParseable)
            {
                if (id is long)
                {
                    dbClass = DBQueryable.FirstOrDefault(e => EF.Property<int>(e, key.Name) == (long)id);
                }
                else if (id is int)
                {
                    dbClass = DBQueryable.FirstOrDefault(e => EF.Property<int>(e, key.Name) == (int)id);
                }
                else
                {
                    dbClass = DBQueryable.FirstOrDefault(e => EF.Property<int>(e, key.Name) == (int)id);
                }
            }
            else
            {
                dbClass = DBQueryable.FirstOrDefault(e => EF.Property<string>(e, key.Name) == (string)id);
            }
            return dbClass;
        }

        public IQueryable<DbModel> GetAll(Expression<Func<DbModel, bool>> condition = null)
        {
            return (condition != null) ? DBQueryable.Where(condition) : DBQueryable.AsQueryable();
        }

        public int GetTotalCounts(Expression<Func<DbModel, bool>> condition = null)
        {
            return (condition != null) ? DBQueryable.Count(condition) : DBQueryable.Count();
        }

        public DbModel Insert(DbModel newObj)
        {
            EntityEntry<DbModel> entity = _dbSet.Add(newObj);
            return entity.Entity;
        }

        public DbModel Update(DbModel newObj)
        {
            return _dbSet.Update(newObj).Entity;
        }

        public bool IsExist(object id)
        {
            var dbItem = GetById(id);
            if (dbItem != null)
            {
                _db.Entry<DbModel>(dbItem).State = EntityState.Detached;
                return true;
            }
            return false;
        }

        public void Delete(object id)
        {
            DbModel dbModel = this.GetById(id);
            this.Delete(dbModel);
        }

        public void Delete(DbModel obj)
        {
            _db.Attach(obj);
            _db.Remove(obj);
        }

        public void DeleteAll(Expression<Func<DbModel, bool>> condition = null)
        {
            IQueryable<DbModel> query = (condition != null) ? DBQueryable.Where(condition) : DBQueryable.AsQueryable();
            foreach (var item in query)
            {
                this.Delete(item);
            }
        }
    }
}