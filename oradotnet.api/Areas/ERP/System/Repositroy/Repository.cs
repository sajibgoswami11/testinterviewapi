using System;
using System.Collections.Generic;
using System.Linq;
using oradotnet.api.Areas.ERP.System.Models;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext  dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public CM_SYSTEM_USERS GetByUsrName(string name)
        {
            return _dbContext.Set<CM_SYSTEM_USERS>().FirstOrDefault(e =>
            e.UserName == name); 

        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }



}
