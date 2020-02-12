using WebApi.Models.Repository;
using WebApi.Data;


namespace WebApi.Models.DataManager
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(webApiContext webApiContext)
            : base(webApiContext)
        {
        }
    }
}
