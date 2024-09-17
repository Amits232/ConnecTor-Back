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

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.UserType)
            .Include(u => u.Region)
            .Include(u => u.Profession)
            .Select(u => new UserDto
            {
                UserID = u.UserID,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Telephone = u.Telephone,
                UserType = u.UserType.UserTypeDescription,
                Region = u.Region.RegionDescription,
                Profession = u.Profession != null ? u.Profession.ProfessionDescription : null,
                UserImage = u.UserImage,
                LicenseCode = u.BusinessLicenseCode,
            })
            .ToListAsync();
    }
}
