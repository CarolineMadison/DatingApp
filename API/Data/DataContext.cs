using API.Entities;
using Microsoft.EntityFrameworkCore;
namespace API.Data;

//this class is derived from an EFC class called DbContext, and gives us a session with our database

public class DataContext : DbContext
{
    //this is a constructor: something run (called) when a new class is created (new instance)
    //constructor will watch for the options we provide it
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    //DbSet reprsents a collection of entities of a specific type - the type specified by the type parameter
    //Users will represent the name of the table when it is created
    public DbSet<AppUser> Users { get; set; }
}