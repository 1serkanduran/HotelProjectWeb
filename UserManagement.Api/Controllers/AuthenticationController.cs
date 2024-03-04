using UserManagement.Api.Services;
using UserManagement.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;

namespace BloggingApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, token) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(token);
                var apiResponse = new LoginResponse
                {
                    UserAbilityRules = new[]
                {
                    new UserAbilityRule
                    {
                        Action = "manage",
                        Subject = "all"
                    }
                },
                    AccessToken = token,
                    UserData = new UserData
                    {
                        Id = 1,
                        FullName = "John Doe",
                        Username = "johndoe",
                        Avatar = "/images/avatars/avatar-1.png",
                        Email = "admin@demo.com",
                        Role = "admin"
                    }
                };

                // Serialize the ApiResponse to JSON
                var json = JsonConvert.SerializeObject(apiResponse, Formatting.Indented);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            //        {
            //            "userAbilityRules": [
            //                {
            //                "action": "manage",
            //        "subject": "all"
            //                }
            //],
            //"accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6Mn0.cat2xMrZLn0FwicdGtZNzL7ifDTAKWB0k1RurSWjdnw",
            //"userData": {
            //                "id": 1,
            //    "fullName": "John Doe",
            //    "username": "johndoe",
            //    "avatar": "/images/avatars/avatar-1.png",
            //    "email": "admin@demo.com",
            //    "role": "admin"
            //}
            //        }
        }
        [HttpPost]
        [Route("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            // token to username

            var (status, message) = await _authService.Logout(token);
            if (status == null)
                return BadRequest("Invalid token");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("User successfully logout!");
        }


        [HttpPost]
        [Route("registeration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Registeration(model, UserRoles.Admin);
                if (status == 0)
                {
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(Register), model);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("removepassword")]
        public async Task<IActionResult> RemovePassword(ForgotPasswordModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.RemovePassword(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("PasswordSet")]
        public async Task<IActionResult> SetPassword(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.AddPassword(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public class UserAbilityRule
        {
            public string Action { get; set; }
            public string Subject { get; set; }
        }

        public class UserData
        {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Username { get; set; }
            public string Avatar { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public class LoginResponse
        {
            public UserAbilityRule[] UserAbilityRules { get; set; }
            public string AccessToken { get; set; }
            public UserData UserData { get; set; }
        }
    }
}