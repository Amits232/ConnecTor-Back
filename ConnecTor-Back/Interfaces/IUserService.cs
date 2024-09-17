using ConnecTor_Back.Dtos;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();

}
