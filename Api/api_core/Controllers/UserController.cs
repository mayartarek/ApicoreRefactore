using api_core.Context;
using api_core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users =await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet("GetUser")]
        public async Task<ActionResult<AppUser>> GetUser(string id)
        {
            var user = _context.Users.FindAsync(id);
            return Ok(user);
        }
    }
}
