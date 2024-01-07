using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using oradotnet.api.Areas.ERP.System.Models;
using Microsoft.Data.Sqlite;
using System.IO;

namespace oradotnet.api.Areas.ERP.System.Repositroy
{
    public class UserService : IUserService
    {

        //public CM_SYSTEM_USERS AddUser(CM_SYSTEM_USERS _users)
        //{
        //    _systemusers.Add(_users);
        //    return _users;
        //}

        public List<CM_SYSTEM_USERS> GetUsers()
        {
            var dataList = new List<CM_SYSTEM_USERS>();
            #region oracle
            //using (IDbConnection db = new OracleConnection(ConString))
            //{

            //    dataList = db.Query<CM_SYSTEM_USERS>("select * from CM_SYSTEM_USERS").ToList();

            //}
            #endregion

            using (IDbConnection db = new SqliteConnection(ConString))
            {

                dataList = db.Query<CM_SYSTEM_USERS>("select * from CM_SYSTEM_USERS").ToList();

            }

            return dataList;
        }

        public List<CM_SYSTEM_USERS> GetUserById(string id, string pass)
        {
            var dataList = new List<CM_SYSTEM_USERS>();
            using (IDbConnection db = new SqliteConnection(ConString))
            {

                string strQry = "SELECT * from CM_SYSTEM_USERS where UserName ='" + id + "' " +
               " and Pasword ='" + pass + "' ";
                dataList = db.Query<CM_SYSTEM_USERS>(strQry, null).ToList();

            }


            return dataList;
        }
        public bool ExecuteUser(string strQry)
        {
            var IsSaved = false;
            using (IDbConnection db = new SqliteConnection(ConString))
            {
                IsSaved = db.Execute(strQry) > 0;
            }


            return IsSaved;
        }
        public int CreateUser(string strQry, string userId, string name, string pass)
        {
            using (IDbConnection db = new SqlConnection(ConString))
            {
                strQry = "INSERT INTO CM_SYSTEM_USERS (SYS_USR_ID, UserName, Password, SYS_USR_EMAIL ) " +
                "VALUES (@SYS_USR_ID,@UserName, @Password , @SYS_USR_EMAIL )";

                //strQry = "INSERT INTO CM_SYSTEM_USERS (SYS_USR_ID, SYS_USR_LOGIN_NAME, SYS_USR_PASS) " +
                //     "VALUES (@SYS_USR_ID,@SYS_USR_LOGIN_NAME, @SYS_USR_PASS )";

                var IsSaved = db.Execute(strQry, new
                {
                    SYS_USR_ID = userId,
                    UserName = name,
                    @SYS_USR_EMAIL = "sds",
                    Password = pass

                });
                return IsSaved;
            }
        }
        public readonly static string ConString = "Data Source='" + Path.Combine(Directory.GetCurrentDirectory() + @"\\portfolio.db") + "' ";

        //string cn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //private static string ConString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User Id =hr; Password =s; ";
        //private static string ConString = "Server=(local)\\sqlexpress; Database=UserDB; Trusted_Connection=True; MultipleActiveResultSets=True;";
        #region authentication
        #endregion
    }
}
