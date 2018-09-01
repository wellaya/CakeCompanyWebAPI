using CakeCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
        Customer GetByIdentityId(string id);
    }
}
