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
        public async Task<List<Employee>> GetDoctor(int depId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Employee> converter = new DynamicModelConverter<Employee>();
                List<Employee> employees = new List<Employee>();
                string query =  $"select * from employee where departmentid = {depId}";
                employees = converter.Get(connection.ConnectionString, query);
                return employees;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Employee>> GetAllDoctor()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Employee> converter = new DynamicModelConverter<Employee>();
                List<Employee> employees = new List<Employee>();
                string query = $"SELECT * FROM employee WHERE employeetype = 1 ";
                employees = converter.Get(connection.ConnectionString, query);
                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<Employee>> GetAllEmployee()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Employee> converter = new DynamicModelConverter<Employee>();
                List<Employee> employees = new List<Employee>();
                string query = "select * from employee";
                employees = converter.Get(connection.ConnectionString, query);
                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
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

        public async Task<List<Employee>> checkLogin(string userName, string password)
        {
            try
            {
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ConHMS").ToString());
                DynamicModelConverter<Employee> converter = new DynamicModelConverter<Employee>();
                List<Employee> serverUser = new List<Employee>();
                string query = $"select * from employee where employeename = '{userName}' and password = '{password}' ";
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
