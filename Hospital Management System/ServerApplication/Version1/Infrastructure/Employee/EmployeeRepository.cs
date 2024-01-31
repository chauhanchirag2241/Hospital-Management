using ServerApplication.Common;
using ServerApplication.Version1.Models;
using System.Data.SqlClient;
using SG =  ServerApplication.Generic;
namespace ServerApplication.Version1.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
       
              private IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> createEmployee(Employee employee)
        {
            try
            {
                SqlConnection connecion = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                //  string query = $@"select * from serveruser where username = '{userName}' and password = '{password}' ";

                DynamicModelConverter<Employee> converter = new DynamicModelConverter<Employee>();
                int employeeadd = converter.Insert(connecion.ConnectionString, employee);

                // return await accountList;
                return employeeadd;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

    }
}
