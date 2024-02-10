using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Infrastructure
{
    public interface IServerUserRepository
    {
        public Task<List<ServerUser>> checkLogin(string userName, string password);
    }
}
