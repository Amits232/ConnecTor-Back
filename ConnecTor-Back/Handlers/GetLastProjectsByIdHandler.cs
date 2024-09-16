using ConnecTor_Back.Dtos;
using ConnecTor_Back.Requests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnecTor_Back.Handlers
{
    public class GetLastProjectsByIdHandler : IRequestHandler<GetLastProjectsByIdQuery, List<LastProjectsDto>>
    {
        private readonly ConnecTorDbContext _context;

        public GetLastProjectsByIdHandler(ConnecTorDbContext context)
        {
            _context = context;
        }

        public async Task<List<LastProjectsDto>> Handle(GetLastProjectsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetLastProjectsById(request.Id, request.Amount);
        }
    }
}
