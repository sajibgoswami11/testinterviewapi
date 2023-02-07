using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using oradotnet.api.Areas.ERP.System.Models;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public interface IUserService
    {
        public List<CM_SYSTEM_USERS> GetUsers();
        public List<CM_SYSTEM_USERS> GetUserById(string id, string pass);

        public bool ExecuteUser(string strQry);
        public int CreateUser(string strQry,string userId,string name,string pass);



    }
}
