using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConnecTor_Back.Dtos;

public class UserService : IUserService
{
    private readonly ConnecTorDbContext _context;

    public UserService(ConnecTorDbContext context)
    {
        _context = context;
    }

    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(int id, User user)
    {
        throw new NotImplementedException();
    }
}
