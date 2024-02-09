using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private IConfiguration _configuration;

        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<department>> GetAllDepartment()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<department> converter = new DynamicModelConverter<department>();
                List<department> departments = new List<department>();
                string query = "select * from department";
                departments = converter.Get(connection.ConnectionString, query);
                return departments;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
