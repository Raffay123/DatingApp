using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UsersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        if(context.Users == null){
            return NotFound();
        }
        var users = await context.Users.ToListAsync();
        return users;
    }

    [Authorize]
    [HttpGet("{id:int}")] // api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        if(context.Users == null){
            return NotFound();
        }
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
}
