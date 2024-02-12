using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;

namespace ServerApplication.Version1.Infrastructure
{
    public class MedicineRepository : IMedicineRepository
    {
        private IConfiguration _configuration;

        public MedicineRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Medicine>> GetAllMedicine()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Medicine> converter = new DynamicModelConverter<Medicine>();
                List<Medicine> medicines = new List<Medicine>();
                string query = "select * from medicine";
                medicines = converter.Get(connection.ConnectionString, query);
                return medicines;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
