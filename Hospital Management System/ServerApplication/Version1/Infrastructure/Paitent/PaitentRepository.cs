using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class PaitentRepository : IPaitentRepository
    {
        private IConfiguration _configuration;

        public PaitentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<paitent>> GetAll()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<paitent> converter = new DynamicModelConverter<paitent>();
                List<paitent> paitents = new List<paitent>();
                string query = $@"SELECT * FROM paitent";
                paitents = converter.Get(connection.ConnectionString, query);
                return paitents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> createPaitent(paitent paitent)
        {
            try
            {
                SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                //  string query = $@"select * from serveruser where username = '{userName}' and password = '{password}' ";

                DynamicModelConverter<paitent> converter = new DynamicModelConverter<paitent>();
                int paitentAdd = converter.Insert(connecion.ConnectionString, paitent);

                // return await accountList;
                return paitentAdd;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
