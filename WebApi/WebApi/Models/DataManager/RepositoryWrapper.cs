using WebApi.Models.DataManager;
using WebApi.Data;
using WebApi.Models.Repository;

namespace WebApi.Models.DataManager
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private webApiContext _repoContext;
        private ICustomersRepository _customer;
        private IAccountRepository _account;
        private ITransactionRepository _transaction;

        public ICustomersRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }

                return _customer;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }

        public ITransactionRepository Transaction
        {
            get
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionRepository(_repoContext);
                }

                return _transaction;
            }
        }

        public RepositoryWrapper(webApiContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }

}
