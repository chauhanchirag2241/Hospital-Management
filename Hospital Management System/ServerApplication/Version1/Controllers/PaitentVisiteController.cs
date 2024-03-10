using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Version1.Infrastructure;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaitentVisiteController : ControllerBase
    {
        private readonly IPaitentVisiteRepository _paitentVisiteRepository;
        public PaitentVisiteController(IPaitentVisiteRepository paitentVisiteRepository)
        {
                _paitentVisiteRepository = paitentVisiteRepository;
        }
        [HttpPost]
        [Route("Add")]
        public Task<int> Add(PaitentVisite? paitentvisite)
        {
            return _paitentVisiteRepository.createVisite(paitentvisite);
        }

        [HttpGet]
        [Route("GetAllAssignPaitent/{emplooyeeId}/{paitentId}")]
        public Task<List<Getpaitentvisite>> GetAllAssignPaitent(int emplooyeeId,int paitentId)
        {
            return _paitentVisiteRepository.GetAllAssignPaitent(emplooyeeId,paitentId);
        }

        [HttpGet]
        [Route("GetAllAssignPaitentInfo/{emplooyeeId}")]
        public Task<List<paitentvisiteInfo>> GetAllAssignPaitenInfo(int emplooyeeId)
        {
            return _paitentVisiteRepository.GetAllAssignPaitentInfo(emplooyeeId);
        }

        [HttpGet]
        [Route("GetPaitentDetailByPaitentId/{paitentId}/{email}")]
        public Task<List<paitentVisiteByPaitentId>>  GetPaitentDetailByPaitentId(int paitentId,string email)
        {
            return _paitentVisiteRepository.GetPaitentDetailByPaitentId(paitentId, email);
        }
        [HttpGet]
        [Route("GetMedicineByPaitentId/{paitentId}/{email}")]
        public Task<List<medicineByPaitentId>> GetMedicineByPaitentId(int paitentId, string email)
        {
            return _paitentVisiteRepository.GetMedicineByPaitentId(paitentId, email);
        }
    }
}
