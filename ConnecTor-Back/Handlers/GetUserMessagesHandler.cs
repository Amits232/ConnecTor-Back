namespace ConnecTor_Back.Handlers
{
    using MediatR;
    using Dapper;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using ConnecTor_Back.Dtos;
    using Microsoft.Extensions.Configuration;
    using ConnecTor_Back.Requests;
    using Microsoft.Data.SqlClient;

    public class GetUserMessagesHandler : IRequestHandler<GetUserMessagesQuery, List<MessageDto>>
    {
        private readonly IDbConnection _dbConnection;

        public GetUserMessagesHandler(IConfiguration configuration)
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

        public async Task<List<MessageDto>> Handle(GetUserMessagesQuery request, CancellationToken cancellationToken)
        {
            var sql = "EXEC GetConversationContent @UserId = @UserId1, @ContactUserId = @UserId2";

            var parameters = new { UserId1 = request.UserId1, UserId2 = request.UserId2 };
            var messages = await _dbConnection.QueryAsync<MessageDto>(sql, parameters);

            return messages.ToList();
        }
    }

}
