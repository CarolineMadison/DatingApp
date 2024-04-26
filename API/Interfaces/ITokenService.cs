using API.Entities;

namespace API.Interface;

public interface ITokenService
{
    //method that returns a string, with the AppUser passed in as an argument
    string CreateToken(AppUser user);
}
