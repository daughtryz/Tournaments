using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tournament.Api.Requests;

namespace Tournament.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sigInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> sigInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _sigInManager = sigInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest registerUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new IdentityUser
            {
                UserName = registerUserRequest.UserName,
                Email = registerUserRequest.Email
            };

            var result = await _userManager.CreateAsync(user, registerUserRequest.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Errors", string.Join(",", result.Errors.Select(x => x.Description)));

                return BadRequest(ModelState);
            }

            return Created();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUserRequest credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _sigInManager.PasswordSignInAsync(credential.UserName, credential.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint.");

                return Unauthorized(ModelState);
            }

            var expiresAt = DateTime.Now.AddMinutes(10);
            var claims = User.Claims;

            return Ok(new
            {
                access_token = CreateToken(claims, expiresAt),
                expires_at = expiresAt,
                username = credential.UserName
            });
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expireAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey") ?? "");

            // generate the JWT
            var jwt = new JwtSecurityToken(
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: expireAt,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(secretKey),
                        SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
