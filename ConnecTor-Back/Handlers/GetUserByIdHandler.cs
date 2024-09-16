using ConnecTor_Back.Dtos;
using ConnecTor_Back.Queries;
using MediatR;

namespace ConnecTor_Back.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly ConnecTorDbContext _context;

        public GetUserByIdHandler(ConnecTorDbContext context)
        {
            _context = context;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetUserById(request.Id);
        }
    }
}
