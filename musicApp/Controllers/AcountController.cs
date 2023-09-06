﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using musicApp.Data.Entities;
using musicApp.Data.Services;
using musicApp.Models.ViewModels;

namespace musicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {

        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;


        public AcountController(UserManager<User> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<UserVM>> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginVM.Password))
            {
                return Unauthorized();
            }



            return new UserVM
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            var user = new User { UserName = registerVM.Username, Email = registerVM.Email };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            return StatusCode(201);

        }


        [Authorize]
        [HttpGet("currentUser")]

        public async Task<ActionResult<UserVM>> GetCurrentUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return new UserVM
            {
                Email = user.Email,
                Token = await _tokenService.GenerateToken(user)
            };
        }
    }
}
