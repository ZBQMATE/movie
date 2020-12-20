using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using movieShop.Core.Models.Request;
using movieShop.Core.Models.Response;
using movieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace movieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.CreateUser(userRegisterRequestModel);
                return Ok(response);
            }

            return BadRequest(new { message = "Please enter correct information" });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            var response = await _userService.GetUserDetails(id);
            return response is null ? BadRequest(new { message = "No user found" }) : Ok(response);
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        //{
        //    if (!ModelState.IsValid) return BadRequest(new { message = "Miss Username/Password" });

        //    var response = await _userService.ValidateUser(loginRequestModel.Email, loginRequestModel.Password);
        //    return response is null ? BadRequest(new { message = "Wrong Username/Password" }) : Ok(response);
        //}

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            if (ModelState.IsValid)
            {
                var userLogin = await _userService.ValidateUser(loginRequestModel.Email, loginRequestModel.Password);
                if (userLogin != null)
                {
                    // success, here geenrate the JWT
                    var token = GenerateJWT(userLogin);
                    return Ok(new { token });
                }
                return Unauthorized();
            }
            return BadRequest(new { message = "Invalid email or password" });
        }

        private string GenerateJWT(UserLoginResponseModel userLoginResponseModel)
        {
            var claims = new List<Claim> {
                     new Claim (ClaimTypes.NameIdentifier, userLoginResponseModel.Id.ToString()),
                     new Claim( JwtRegisteredClaimNames.GivenName, userLoginResponseModel.FirstName ),
                     new Claim( JwtRegisteredClaimNames.FamilyName, userLoginResponseModel.LastName ),
                     new Claim( JwtRegisteredClaimNames.Email, userLoginResponseModel.Email )
            }; var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims); 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSettings:PrivateKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<double>("TokenSettings:ExpirationHours")); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Audience = _configuration["TokenSettings:Audience"],
                Issuer = _configuration["TokenSettings:Issuer"],
                SigningCredentials = credentials,
                Expires = expires
            }; 
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodedToken);
        }


    }
}
