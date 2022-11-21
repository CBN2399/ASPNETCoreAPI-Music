#nullable disable
using ApiProyect.Data;
using ApiProyect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiProyect.Controllers
{
    [Route("/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(UserManager<AppUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("Login")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(string email, string password)
        {
            if (String.IsNullOrEmpty(email) && (String.IsNullOrEmpty(password)))
            {
                return BadRequest("El email y la contaseña son obligatorias");
            }
            else
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Email == email );
                if (user == null)
                {
                    return NotFound("El usuario no existe");
                }
                else
                {
                    var correct = _userManager.CheckPasswordAsync(user, password);
                    if (!await correct)
                    {
                        return BadRequest("La contraseña es incorrecta");
                    }
                    else
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        var claims = new List<Claim>
                            {
                                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim (JwtRegisteredClaimNames. Iat, DateTime.UtcNow.ToString()),
                                new Claim("UserId", user.Id),
                                new Claim ("UserName", user.UserName),
                                new Claim("Email", user. Email),
                            };
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        signingCredentials: credentials);
                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                }
            }

        }
        [Route("Register")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register( [FromBody] AppUser user)
        {
            if ((String.IsNullOrEmpty(user.Email)) && (String.IsNullOrEmpty(user.clave)))
            {
                return BadRequest("El email y la contraseña son obligatorias");
            }
            var users = await _userManager.Users.ToListAsync();
            var Existuser = users.Find(x => x.Email == user.Email);
            if (Existuser != null)
            {
                return BadRequest("El usuario ya esta registrado");
            }

 
            AppUser newUser = new AppUser
            {
                Nombre = user.Nombre,
                Apellidos = user.Apellidos,
                PostalCode = user.PostalCode,
                UserName = user.Email,
                NormalizedUserName = user.NormalizedEmail.ToUpper(),
                Email = user.Email,
                NormalizedEmail = user.NormalizedEmail.ToUpper(),
                EmailConfirmed = true,
            };
            var passwordHasher = new PasswordHasher<AppUser>();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, user.clave);

            await _userManager.CreateAsync(newUser);
            await _userManager.AddToRoleAsync(newUser, "default");
            return Ok("Usuario registrado correctamente");

        }
        

    }
}
