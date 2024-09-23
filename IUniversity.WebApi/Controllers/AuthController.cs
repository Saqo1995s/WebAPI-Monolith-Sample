using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IUniversity.Common.Models.Base;
using IUniversity.Common.Models.Requests;
using IUniversity.Common.Models.Responses;
using IUniversity.Core.Repository.Interface;
using IUniversity.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IUniversity.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<LearningPlatformIdentityUser> _userRepository;
        private readonly Authenticator _authenticator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AuthController(
            UserManager<LearningPlatformIdentityUser> userRepository,
            Authenticator authenticator,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _authenticator = authenticator;
            _refreshTokenRepository = refreshTokenRepository;
        }

        [HttpHead("ping")]
        public OkResult Ping()
        {
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList(),
                    Success = false
                });
            }

            if (registerRequest.Password != registerRequest.ConfirmPassword)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string> { "Password does not match confirm password." },
                    Success = false
                });
            }

            var existingUser = await _userRepository.FindByEmailAsync(registerRequest.Email);

            if (existingUser != null)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "Email already in use" },
                    Success = false
                });
            }

            LearningPlatformIdentityUser registrationUser = new LearningPlatformIdentityUser()
            {
                Email = registerRequest.Email,
                UserName = registerRequest.Username,
                Role = registerRequest.Role 
            };

            IdentityResult result = await _userRepository.CreateAsync(registrationUser, registerRequest.Password);

            if (result.Succeeded)
            {
                var jwtResult = await _authenticator.Authenticate(registrationUser);
                return Ok(jwtResult);
            }
            else
            {
                return BadRequest(new AuthResult()
                {
                    Errors = result.Errors.Select(x => x.Description).ToList(),
                    Success = false
                });
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResult>> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList(),
                    Success = false
                });
            }

            LearningPlatformIdentityUser existingUser = await _userRepository.FindByNameAsync(loginRequest.Username);
            if (existingUser == null)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "Invalid login request" },
                    Success = false
                });
            }

            bool isCorrectPassword = await _userRepository.CheckPasswordAsync(existingUser, loginRequest.Password);
            if (!isCorrectPassword)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "Invalid login request" },
                    Success = false
                });
            }

            AuthResult jwtResult = await _authenticator.Authenticate(existingUser);

            return Ok(jwtResult);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest refreshRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList(),
                    Success = false
                });
            }

            var result = await _authenticator.VerifyAndGenerateToken(refreshRequest);
            if (result == null)
            {
                return BadRequest(new AuthResult()
                {
                    Errors = new List<string>() { "Invalid tokens" },
                    Success = false
                });
            }

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            string rawUserId = HttpContext.User.FindFirstValue("id");

            if (!Guid.TryParse(rawUserId, out Guid userId))
            {
                return Unauthorized();
            }

            await _refreshTokenRepository.DeleteAll(userId);

            return NoContent();
        }
    }
}