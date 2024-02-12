using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Version1.Infrastructure;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineRepository _medicineRepository;
        public MedicineController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        [Route("GetAllMedicine")]
        public Task<List<Medicine>> GetAllMedicine()
        {
            return _medicineRepository.GetAllMedicine();
        }
    }
}
