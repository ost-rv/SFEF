using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFEF.Models;

namespace SFEF.Repository
{
    public class Repository<T> where T : IEntity
    {
        protected SFEFContext _dbContext;
        public Repository(SFEFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual List<T> GetList()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
