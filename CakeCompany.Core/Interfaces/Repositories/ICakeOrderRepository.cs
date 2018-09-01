using CakeCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core.Interfaces.Repositories
{
    public interface ICakeOrderRepository
    {
        Task<List<CakeOrder>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<CakeOrder> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<CakeOrder> AddAsync(CakeOrder cakeOrder, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(CakeOrder cakeOrder, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
