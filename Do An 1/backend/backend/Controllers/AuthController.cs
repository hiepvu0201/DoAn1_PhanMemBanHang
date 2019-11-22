using backend.Models;
using backend.Models.BindingTargets;
using backend.Models.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterData userData)
        {
            userData.Username = userData.Username.ToLower();

            if (await _repo.UserExists(userData.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = new User
            {
                Username = userData.Username
            };

            var createUser = await _repo.Register(userToCreate, userData.Password);

            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginData userData)
        {
            try
            {
                var userFromRepo = await _repo.Login(userData.UserName.ToLower(), userData.Password);

                if (userFromRepo == null)
                    return Unauthorized();

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });
            }
            catch
            {
                return StatusCode(500, "Error!");
            }
            
        }
    }   
}



