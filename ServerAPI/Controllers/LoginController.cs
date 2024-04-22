using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (_loginRepository.Verify(user.Username, user.Password))
            {
                // Authentication logic here
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { Message = "Login failed" });
            }
        }
    }

