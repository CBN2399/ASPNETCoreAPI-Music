using ApiProyect.Data;
using ApiProyect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProyect.Controllers
{
    //[Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<AppUser>>> Get()
        {
            var user = await _userContext.Users.ToListAsync();
           // await _userManager.
            return (user);
        }
    }
}
