
using ASMSapi.Model;
using  ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Repository
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetUser(string userName , string password);
        public Task<List<Account>> CreateUser(Account account);
    }
}
