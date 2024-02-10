using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class ServerUserRepository : IServerUserRepository
    {
        private readonly IConfiguration _configuration;
        public ServerUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ServerUser>> checkLogin(string userName, string password)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<ServerUser> converter = new DynamicModelConverter<ServerUser>();
                List<ServerUser> serverUser = new List<ServerUser>();
                string query = $"select * from serveruser where username = '{userName}' and password = '{password}' ";
                serverUser = converter.Get(connection.ConnectionString, query);
                return serverUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
