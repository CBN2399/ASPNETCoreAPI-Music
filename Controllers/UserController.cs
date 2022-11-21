using ApiProyect.Data;
using ApiProyect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProyect.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;
        private readonly UserManager<AppUser> _userManager;
        public UserController(UserContext userContext, UserManager<AppUser> userManager)
        {
            _userContext = userContext;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            foreach(var user in _userManager.Users)
            {
                user.Roles = await _userManager.GetRolesAsync(user);
            }
            return Ok(await _userContext.Users.ToListAsync());
        }
    }
}
