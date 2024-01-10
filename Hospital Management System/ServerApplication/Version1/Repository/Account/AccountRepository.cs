using ServerApplication.Version1.Models;

namespace ServerApplication.Version1.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private  IAccountRepository _accountRepository;
     
        public Task<Account> CreateUser(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
