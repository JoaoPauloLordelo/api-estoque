using AprendizadoCSharp.Application.DTOs.Auth;
using AprendizadoCSharp.Domain.Authentication.Interfaces;
using AprendizadoCSharp.Domain.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoCSharp.Application.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._tokenService = tokenService;
            this._signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUser? user = await this._userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginDto.Username.ToLower());
            if(user == null)
            {
                return Unauthorized("Invalid Username or Password");
            }

            var result = await this._signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Username or Password");
            }

            return Ok(new NewUserDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = this._tokenService.CreateToken(user)
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                AppUser appUser = new AppUser
                {
                    UserName = dto.Username,
                    Email = dto.Email
                };
                IdentityResult createdUser = await this._userManager.CreateAsync(appUser, dto.Password);
                if (createdUser.Succeeded)
                {
                    IdentityResult roleResult = await this._userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(new NewUserDTO
                        {
                            UserName = appUser.UserName,
                            Email = appUser.Email,
                            Token = this._tokenService.CreateToken(appUser)
                        });
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);

                }
            }
            catch(Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}
