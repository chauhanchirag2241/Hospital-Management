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

        [HttpGet]
        [Route("GetDoctor/{depId}")]        
        public Task<List<Employee>> GetDoctor(int depId)
        {
            return _employeeRepository.GetDoctor(depId);
        }

        [HttpGet]
        [Route("GetAllDoctor")]
        public Task<List<Employee>> GetAllDoctor()
        {
            return _employeeRepository.GetAllDoctor();
        }

        [HttpPost]
        [Route("Add")]
        public Task<int> Add(Employee employee)
        {

            return _employeeRepository.createEmployee(employee);
        }

        [HttpGet]
        [Route("checkLogin/{userName}/{password}")]
        public Task<List<Employee>> checkLogin(string userName, string password)
        {
            return _employeeRepository.checkLogin(userName, password);
        }
    }
}
