namespace ConnecTor_Back.Requests
{
    using MediatR;
    using System.Collections.Generic;
    using ConnecTor_Back.Dtos;

    public class GetUserMessagesQuery : IRequest<List<MessageDto>>
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }

        public GetUserMessagesQuery(int userId1, int userId2)
        {
            UserId1 = userId1;
            UserId2 = userId2;
        }
    }

}
