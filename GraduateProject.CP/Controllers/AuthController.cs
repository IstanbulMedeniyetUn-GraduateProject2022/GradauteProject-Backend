using GraduateProject.CP.Models;
using GraduateProject.CP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.CP.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private IMailService _mailService;
        private IConfiguration _configuration;
        public AuthController(IAuthService authService, IMailService mailService, IConfiguration configuration) 
        {
            _authService = authService;
            _mailService = mailService;
            _configuration = configuration;
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid) //when modelState is true, that isn't mean registeration operation will be executing!! Because in ModelState we check only the validation of values
                                     //Also if the username/email is already exit, the registration  won't be executing! (we checked this point in RegisterAsync function in AuthService class)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);

            if (!result.IsAuthenticated) //so if the username/email is already exit, IsAuthenticated will be false. Otherwise will be true. 
                return BadRequest(result.Message);

            return Ok(new { Username=result.Username, Email=result.Email, Role=result.Roles, token=result.Token, ExpiresOn=result.ExpiresOn });//return as you want from these values
        }

        [AllowAnonymous] //AllowAnonymous: user who don't have any special validity
        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.GetTokenAsync(model);

                if (result.IsAuthenticated)
                {
                    await _mailService.SendEmailAsync(model.Email, "New login", "<h1>Hey!, new login to your account noticed</h1><p>New login to your account at " +DateTime.Now+ "</p>");
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest(ModelState);
        }


        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        // /api/auth/confirmemail?userid&token
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _authService.ConfirmEmailAsync(userId, token);

            if (result.IsAuthenticated)
            {
                return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
            }

            return BadRequest(result);
        }

        [AllowAnonymous] //is it true
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email) {
            if (string.IsNullOrEmpty(email))
                return NotFound();
            var result = await _authService.ForgetPasswordAsync(email);
            if (result.IsAuthenticated)
                return Ok(result);
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model) {
            if (ModelState.IsValid)
            {
                var result = await _authService.ResetPasswordAsync(model);
                if (result.IsAuthenticated)
                    return Ok(model);
                return BadRequest();
            }
            return BadRequest("some properties are not valid");
        }

    }
}
