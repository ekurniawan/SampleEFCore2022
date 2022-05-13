using MyIdentityServer.DTO;

namespace MyIdentityServer.Data
{
    public interface IUser
    {
        Task Registration(CreateUserDto user);
        Task<UserDto> Authenticate(string username, string password);
    }
}
