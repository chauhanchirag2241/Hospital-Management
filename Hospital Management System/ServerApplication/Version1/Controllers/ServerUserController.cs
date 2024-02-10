using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApplication.Version1.Infrastructure;

using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerUserController : ControllerBase
    {
        private readonly IServerUserRepository _serverUserRepository;
        public ServerUserController(IServerUserRepository serverUserRepository)
        {
            _serverUserRepository = serverUserRepository;
        }

        [HttpGet]
        [Route("checkLogin/{userName}/{password}")]
        public Task<List<ServerUser>> checkLogin(string userName, string password)
        {
            return _serverUserRepository.checkLogin(userName, password);
        }
    }
}
