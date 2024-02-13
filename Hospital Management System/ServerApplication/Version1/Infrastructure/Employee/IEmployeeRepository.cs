using ASMSapi.Model;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IEmployeeRepository
    {
        public Task<int> createEmployee(Employee  employee);
        public Task<List<Employee>> GetAllEmployee();
        public Task<List<Employee>> GetDoctor(int depId);

        public Task<List<Employee>> checkLogin(string userName, string password);
    }
}
