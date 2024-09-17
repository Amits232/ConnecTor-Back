using MediatR;
using System.Collections.Generic;
using ConnecTor_Back.Dtos;

public class GetUserConversationsQuery : IRequest<List<ConversationDto>>
{
    public int UserId { get; }

    public GetUserConversationsQuery(int userId)
    {
        UserId = userId;
    }
}
