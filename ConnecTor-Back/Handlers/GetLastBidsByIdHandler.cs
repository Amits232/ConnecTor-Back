using ConnecTor_Back.Dtos;
using ConnecTor_Back.Requests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConnecTor_Back.Handlers
{
    public class GetLastBidsByIdHandler : IRequestHandler<GetLastBidsByIdQuery, List<LastBidsDto>>
    {
        private readonly ConnecTorDbContext _context;

        public GetLastBidsByIdHandler(ConnecTorDbContext context)
        {
            _context = context;
        }

        public async Task<List<LastBidsDto>> Handle(GetLastBidsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetLastBidsById(request.Id, request.Amount);
        }
    }
}
