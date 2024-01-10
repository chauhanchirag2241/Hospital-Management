using BE = ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Repository
{
    public interface IAccountRepository
    {
        public Task<BE.Account> GetUser(string userName , string password);
        public Task<BE.Account> CreateUser(BE.Account account);
    }
}
