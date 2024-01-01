using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Helper;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public class Login 
    {

        private readonly AppSettings _appSettings;

        public Login(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


    }
    public class AppSettings
    {
        public string Key { get; set; }
    }
}
