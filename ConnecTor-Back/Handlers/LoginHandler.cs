using ConnecTor_Back.Interfaces;
using ConnecTor_Back.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConnecTor_Back.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly ConnecTorDbContext _context;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginHandler(ConnecTorDbContext context, IJwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.UserPassword == request.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            // Generate a JWT token
            var token = _tokenGenerator.GenerateToken(user);
            return token;
        }
    }
}
