using ConnecTor_Back.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ConnecTor_Back.Requests
{
    public class GetLastProjectsByIdQuery : IRequest<List<LastProjectsDto>>
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public GetLastProjectsByIdQuery(int id, int amount)
        {
            Id = id;
            Amount = amount;
        }
    }
}
