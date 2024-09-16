using ConnecTor_Back.Dtos;
using MediatR;

namespace ConnecTor_Back.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
