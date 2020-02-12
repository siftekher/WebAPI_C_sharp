using WebApi.Models.Repository;
using WebApi.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models.DataManager
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomerRepository(webApiContext webApiContext)
            : base(webApiContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return FindAll()
                .OrderBy(ow => ow.CustomerID)
                .ToList();
        }

        public Customer GetCustomer(int CustomerID)
        {
            return FindByCondition(x => x.CustomerID.Equals(CustomerID)).FirstOrDefault();
        }

        public Customer GetCustomerWithAccounts(int CustomerID)
        {
            return FindByCondition(x => x.CustomerID.Equals(CustomerID))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }

    }
}
