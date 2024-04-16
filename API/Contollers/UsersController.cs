using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;


[ApiController]


[Route("api/[controller]")] // api/users, Angular client will hit this controller and endpoints

//derived from ControllerBase class, Base class for MVC controller (Model, View, Controller); In an API contoller we don't return a view but an HTTP response
public class UsersController : ControllerBase
{
    //private readonly field gives the rest of the class (other methods) access to context
    private readonly DataContext _context;

    //inject stuff into our controller with a constructor, DataContext is what we are injecting
    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
    {

        var users = await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}