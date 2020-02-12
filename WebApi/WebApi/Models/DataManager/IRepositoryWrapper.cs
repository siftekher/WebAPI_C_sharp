using WebApi.Models.Repository;


namespace WebApi.Models.DataManager
{
    public interface IRepositoryWrapper
    {
        ICustomersRepository Customer { get; }
        IAccountRepository Account { get; }

        ITransactionRepository Transaction { get; }
        void Save();
    }
}
