using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace NotePadWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RegisterService _register;
        private readonly LoginService _login;

        public UserController(RegisterService register, LoginService login)
        {
            _register = register;
            _login = login;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var result = _register.RegisterProcess(registerDto.Name, registerDto.Email, registerDto.Password);

            return StatusCode(result._StatusCode, new { Message = result._Message });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var result = _login.LoginProcess(loginDto.Email, loginDto.Password);

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : new { Id = result._Data });
        }
    }
}