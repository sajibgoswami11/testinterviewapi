using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Areas.ERP.System.Repositroy;
using oradotnet.api.Helper;

namespace oradotnet.api.Areas.ERP.System.Controllers
{
    [Route("api/ERP/System/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _repository;

        public LoginController(ILogin login)
        {
            _repository = login;
        }

        [HttpPost]
        public IActionResult Login(CM_SYSTEM_USERS us)
        {
            try
            {
                CryptoLibrary crypto = new CryptoLibrary();

                var key = "FINTech^%$#@!Trn";

                //var check = crypto.Encrypt("Noyon892", key);

                var userName = crypto.Decrypt(us.UserName, key);
                var password = crypto.Decrypt(us.Password, key);

                //var userName =us.UserName; var password= us.Password;
                TokenModel token = _repository.Authenticate(userName, password);

                if (token == null)
                {
                    return BadRequest(new { message = "Username or Password Incorrect" });
                }

                if (token.Token.Split('.').Length < 2)
                {
                    return BadRequest(new { message = "Something went wrong!" });
                }

                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
