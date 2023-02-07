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
    public class Login : ILogin
    {

        private readonly AppSettings _appSettings;
        private readonly string _conString;

        public Login(IOptions<AppSettings> appSettings)
        {
            _conString = AppSettings.ConString;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<CM_SYSTEM_USERS> GetUserById(string id, string pass)
        {
            var dataList = new List<CM_SYSTEM_USERS>();
            using (IDbConnection db = new SqlConnection(_conString))
            {

                string strQry = "SELECT * from CM_SYSTEM_USERS where UserName ='" + id + "' " +
               " and Password ='" + pass + "' ";
                dataList = db.Query<CM_SYSTEM_USERS>(strQry, null).ToList();

            }


            return dataList;
        }

        public TokenModel Authenticate(string userName, string password)
        {
            IEnumerable<CM_SYSTEM_USERS> user;
             user = GetUserById(userName, password);
            //return null
            if (user.Count() == 0)
            {
                return null;
            }

            //User Found
            var tokenHandlar = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName ),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V2.1")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            TokenModel tok = new TokenModel();
            var token = tokenHandlar.CreateToken(tokenDescriptor);
            tok.Token = tokenHandlar.WriteToken(token);
            tok.UserName = userName;           //user.Password = null;
            return tok;
        }
    }
    public class AppSettings
    {
        public string Key { get; set; }
        public static string ConString = "Server=(localdb)\\MSSQLLocalDB; Database=UserDB; Trusted_Connection=True; MultipleActiveResultSets=True;";

    }
}
