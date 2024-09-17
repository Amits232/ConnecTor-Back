using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using ConnecTor_Back.Interfaces;
using ConnecTor_Back.Requests;
using MediatR;

public class LoginHandler : IRequestHandler<LoginQuery, string>
{
    private readonly ConnecTorDbContext _context;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly PasswordHasher<User> _passwordHasher;

    public LoginHandler(ConnecTorDbContext context, IJwtTokenGenerator tokenGenerator)
    {
        _context = context;
        _tokenGenerator = tokenGenerator;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.UserPassword, request.Password);
        if (passwordVerificationResult != PasswordVerificationResult.Success)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }

        var token = _tokenGenerator.GenerateToken(user);
        return token;
    }
}
