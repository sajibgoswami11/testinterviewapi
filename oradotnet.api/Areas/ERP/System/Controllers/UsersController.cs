using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Areas.ERP.System.Repositroy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace oradotnet.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/ERP/System/[controller]")]
    public class UsersController : Controller
    {
        private ILogger _logger;
        private IUserService _user_service;
        public UsersController(ILogger<UsersController> logger, IUserService user_service)
        {
            _logger = logger;
            _user_service = user_service;

        }

        // GET: api/ERP/System/<controller>
        [HttpGet]
        public ActionResult<List<CM_SYSTEM_USERS>> Get()
        {
            return _user_service.GetUsers();
        }

        // GET api/<ERP/System/controller>/5
        [HttpGet("{id}/{pass}")]
        public ActionResult<List<CM_SYSTEM_USERS>> GetById(string id, string pass, CM_SYSTEM_USERS usr)
        {
            if (id == null || pass == null)
            {
                return null;
            }
            else
            {
                var data = _user_service.GetUserById(id, pass);

                if (data == null || data.Count == 0)
                {
                    return null;
                }
                else
                { return data; }
            }
        }

        // POST api/<ERP/System/controller>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CM_SYSTEM_USERS> Create([FromBody] CM_SYSTEM_USERS usr)
        {

            if (ModelState.IsValid && usr != null)
            {
                string strQry = "";
                _user_service.CreateUser(strQry, usr.SYS_USR_ID, usr.UserName, usr.Password);

                return CreatedAtAction(nameof(GetById), new { id = usr.SYS_USR_ID }, usr);
            }
            else
            {
                return BadRequest();
            }
            
        }
        [Route("createtask")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CM_SYSTEM_USERS> CreateTask([FromBody] CM_SYSTEM_USERS usr)
        {

            if (ModelState.IsValid && usr != null)
            {
                string strQry = "UPDATE CM_SYSTEM_USERS SET " +  // 
                   " taskName= '" + usr.taskName + "', taskImage='" + usr.taskImage + "'," +
                   "  WHERE UserName='" + usr.UserName + "'  ";


                _user_service.ExecuteUser(strQry);

                return CreatedAtAction(nameof(GetById), new { id = usr.SYS_USR_ID }, usr);
            }
            else
            {
                return BadRequest();
            }
            
        }


        // PUT api/<ERP/System/controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] CM_SYSTEM_USERS usr)
        {
            if (ModelState.IsValid && usr != null && id == usr.SYS_USR_ID)
            {
                string strQry = "UPDATE CM_SYSTEM_USERS SET " +  // 
                    " SYS_USR_LOGIN_NAME= '" + usr.UserName + "', SYS_USR_PASS='" + usr.Password + "'," +
                    " SYS_USR_DNAME='" + usr.SYS_USR_DNAME + "' , SYS_USR_EMAIL ='" + usr.SYS_USR_EMAIL + "' WHERE SYS_USR_ID='" + usr.SYS_USR_ID + "'  ";

                 _user_service.ExecuteUser(strQry);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
