using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ConnecTor_Back.Dtos;
using Microsoft.Data.SqlClient;

public class GetUserConversationsHandler : IRequestHandler<GetUserConversationsQuery, List<ConversationDto>>
{
    private readonly IDbConnection _dbConnection;

    public GetUserConversationsHandler(IConfiguration configuration)
    {
        var machineName = Environment.MachineName;
        if (machineName == "DESKTOP-N6FQQ59")
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection1"));
        }
        else
        {
            _dbConnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection2"));
        }
    }

    public async Task<List<ConversationDto>> Handle(GetUserConversationsQuery request, CancellationToken cancellationToken)
    {
        var sql = "EXEC GetUserConversations @UserId";
        var parameters = new { UserId = request.UserId };

        var conversations = await _dbConnection.QueryAsync<ConversationDto>(sql, parameters);

        return conversations.ToList();
    }
}
