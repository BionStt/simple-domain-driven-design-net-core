using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MinimalDDD.Api.Auth;
using MinimalDDD.Domain;
using MinimalDDD.Domain.Aggregations.Users;
using TGAuth.Service.Auth;

namespace MinimalDDD.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("auth")]
        [DisableCors]
        [AllowAnonymous]
        public async Task<IActionResult> Auth(
            [FromBody] User user,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations)

        {
            bool authorized = _userRepository.Auth(user).Result;

            if (authorized)
                return Unauthorized();

            var response = await user.JWTAuthorization(signingConfigurations, tokenConfigurations);

            return Ok(response);
        }

        [HttpPost("change")]
        [AllowAnonymous]
        [DisableCors]
        public async Task<IActionResult> Change([FromBody]User user)
        {
            await _userRepository.Change(user);
            return Ok();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [DisableCors]
        public async Task<IActionResult> Register([FromBody]User user)
        {
            if (user.ExistErros())
                return BadRequest(user.erros);
            else
                await _userRepository.Register(user);

            return Ok(true);
        }

        [HttpGet]
        [AllowAnonymous]
        [DisableCors]
        public async Task<IActionResult> GetAll()
        {
            var usersInDataBaseMemory = await _userRepository.GetAll();
            
            if (usersInDataBaseMemory.Any())
                return Ok(usersInDataBaseMemory);

            return NoContent();
        }

        [HttpGet("{userId}")]
        [AllowAnonymous]
        [DisableCors]
        public async Task<IActionResult> GetUser(int userId)
        {
            var userInDataBase = await _userRepository.GetUser(userId);
            if (userInDataBase == null)
                return Ok(MessageService.Message(MessageSystem.UserNotFound));

            return Ok(userInDataBase);
        }
    }
}