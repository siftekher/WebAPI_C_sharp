using System.Collections.Generic;
using WebApi.Models;
using WebApi.Models.Repository;

namespace WebApi.Models.Repository
{
    public interface ICustomersRepository : IRepositoryBase<Customer>
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomer(int CustomerID);
        Customer GetCustomerWithAccounts(int CustomerID);

    }
}
