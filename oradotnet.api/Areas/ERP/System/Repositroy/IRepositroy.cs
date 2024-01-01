using oradotnet.api.Areas.ERP.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public interface IRepository<T>
    {
        CM_SYSTEM_USERS GetByUsrName(string userName);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
