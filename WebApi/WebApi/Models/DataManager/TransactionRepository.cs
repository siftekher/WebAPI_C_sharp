using WebApi.Models.Repository;
using WebApi.Data;

namespace WebApi.Models.DataManager
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(webApiContext webApiContext)
            : base(webApiContext)
        {
        }
    }
}
