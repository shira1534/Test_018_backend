using BLL;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserLogic _logic;
        public UserController(IUserLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto u)
        {

            if (!_logic.IsExsist(u))
            {
                return NotFound("אין כזה מישתמש");
            }
            return Ok(_logic.Login(u.Mail, u.Password));

        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserDto u)
        {

            if (_logic.IsExsist(u))
            {
                return Ok(null);
            }
            return Ok(_logic.Register(u));
        }
      
    }
}
