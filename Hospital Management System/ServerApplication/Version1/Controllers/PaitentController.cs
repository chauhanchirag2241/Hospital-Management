using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Version1.Infrastructure;
using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaitentController : ControllerBase
    {
        private readonly IPaitentRepository _paitentRepository;
        public PaitentController(IPaitentRepository paitentRepository)
        {
            _paitentRepository = paitentRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<List<paitent>> GetAll()
        {
            return _paitentRepository.GetAll();
        }

        [HttpGet]
        [Route("GetPaitentByPaitentId/{paitentId}")]
        public Task<List<paitent>> GetPaitentByPaitentId(int paitentId)
        {
            return _paitentRepository.GetPaitentByPaitentId(paitentId);
        }


        [HttpPost]
        [Route("Add")]
        public Task<int> Add(paitent paitent)
        {

            return _paitentRepository.createPaitent(paitent);
        }
    }
}
