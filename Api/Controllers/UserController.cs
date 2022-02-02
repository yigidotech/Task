using System;
using System.Collections.Generic;
using System.Linq;
using Api.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Services;
using Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private UserService userService;
        public UserController(ILogger<UserController> logger, TaskContext taskContext, IConfiguration configuration)
        {
            _logger = logger;
            this.userService = new UserService(taskContext, configuration);
        }

        [HttpPost("sign-in")]
        public async System.Threading.Tasks.Task<ActionResult<User>> SignIn([FromBody] User user)
        {
            try
            {
                var result = await userService.SignIn(user);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        [HttpGet("login")]
        public async System.Threading.Tasks.Task<LoginResponse> Login(string username, string password)
        {
            return await this.userService.Login(username, password);
        }

    }
}
