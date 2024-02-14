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
        public Task<int> Add(paitentvisite paitentvisite)
        {
            return _paitentVisiteRepository.createVisite(paitentvisite);
        }

        [HttpGet]
        [Route("GetAllAssignPaitent/{emplooyeeId}")]
        public Task<List<paitentvisite>> GetAllAssignPaitent(int emplooyeeId )
        {
            return _paitentVisiteRepository.GetAllAssignPaitent(emplooyeeId);
        }

    }
}
