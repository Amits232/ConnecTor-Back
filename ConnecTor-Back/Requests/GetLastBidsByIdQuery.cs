using ConnecTor_Back.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ConnecTor_Back.Requests
{
    public class GetLastBidsByIdQuery : IRequest<List<LastBidsDto>>
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public GetLastBidsByIdQuery(int id, int amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
