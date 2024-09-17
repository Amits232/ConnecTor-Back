using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ConnecTor_Back.Handlers
{
    public class UserRegisterHandler : IRequestHandler<UserRegisterQuery, bool>
    {
        private readonly ConnecTorDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserRegisterHandler(ConnecTorDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(UserRegisterQuery request, CancellationToken cancellationToken)
        {
            var validUserType = await _context.UserTypes
                .AnyAsync(ut => ut.UserTypeID == request.UserTypeID, cancellationToken);

            if (!validUserType)
            {
                return false;
            }

            var user = new User
            {
                Email = request.Email,
                UserPassword = _passwordHasher.HashPassword(null, request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                RegionID = request.RegionID,
                ProfessionID = request.ProfessionID,
                BusinessLicenseCode = request.BusinessLicenseCode,
                Telephone = request.Telephone,
                UserImage = request.UserImage,
                UserTypeID = request.UserTypeID
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

    }
}