namespace ConnecTor_Back.Interfaces
{

    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }

}
