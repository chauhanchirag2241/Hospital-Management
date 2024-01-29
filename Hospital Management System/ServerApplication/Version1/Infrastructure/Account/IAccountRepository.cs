
using ASMSapi.Model;
using  ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Repository
{
    public interface IAccountRepository
    {
        public Task<Response> GetUser(string userName , string password);
        public Task<Response> CreateUser(Account account);
    }
}
