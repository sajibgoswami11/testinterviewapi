using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using oradotnet.api.Areas.ERP.System.Models;
using oradotnet.api.Areas.ERP.System.Repositroy;
using oradotnet.api.Helper;

namespace oradotnet.api.Areas.ERP.System.Controllers
{
    [Route("api/ERP/System/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepository<CM_SYSTEM_USERS> _loginService;

        private readonly AppSettings _appSettings;

        public LoginController(IOptions<AppSettings> appSettings,IRepository<CM_SYSTEM_USERS> loginRepos)
        {
            _loginService = loginRepos;
            _appSettings = appSettings.Value;


        }

        [HttpPost]
        public IActionResult Login(CM_SYSTEM_USERS us)
        {
            try
            {
               // CryptoLibrary crypto = new CryptoLibrary();

                //var key = "FINTech^%$#@!Trn";

                ////var check = crypto.Encrypt("Noyon892", key);

                //var userName = crypto.Decrypt(us.UserName, key);
                //var password = crypto.Decrypt(us.Password, key);

                var userName = us.UserName; var password = us.SYS_USR_PASS;
                var usrByAuth = _loginService.GetByUsrName(userName);
                if (usrByAuth != null && usrByAuth.SYS_USR_PASS == password)
                {
                   var authUser= usrByAuth.UserName;
                   
                }
                else
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
                    new Claim(ClaimTypes.Name,  userName ),
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
                tok.UserName = userName;

                if (token == null)
                {
                    return BadRequest(new { message = "Username or Password Incorrect" });
                }

                if (tok.Token.Split('.').Length < 2)
                {
                    return BadRequest(new { message = "Something went wrong!" });
                }

                return Ok(tok);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

       
    }
}
