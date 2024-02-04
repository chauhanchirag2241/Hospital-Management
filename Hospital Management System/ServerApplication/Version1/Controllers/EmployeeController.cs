using ASMSapi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Version1.Infrastructure;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("GetAllEmployee")]
        public Task<List<Employee>> GetAllEmployee()
        {
            return _employeeRepository.GetAllEmployee();
        }

        [HttpPost]
        [Route("Add")]
        public Task<int> Add(Employee employee)
        {

            return _employeeRepository.createEmployee(employee);
        }
    }
}
