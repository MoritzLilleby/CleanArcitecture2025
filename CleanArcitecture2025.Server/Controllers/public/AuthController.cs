using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitecture2025.Server.Controllers.@public
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Username == "test" && login.Password == "password")
            {
                var token = GenerateJwtToken();
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("yourLongSecretKey123yourLongSecretKey123yourLongSecretKey123yourLongSecretKey123"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define your claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, "yourUserId"),
                new Claim(JwtRegisteredClaimNames.Email, "user@example.com"),
                new Claim("customClaimType", "customClaimValue")
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:7147", // Optional for POC
                audience: "yourAudience", // Optional for POC
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
