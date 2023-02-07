using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public interface ILogin
    {
        public IEnumerable<CM_SYSTEM_USERS> GetUserById(string id, string pass);
        TokenModel Authenticate(string userName, string Password);
    }
}
