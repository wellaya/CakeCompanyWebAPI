using CakeCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Core.Interfaces.Repositories
{
    public interface IToppingRepository
    {
        Task<List<Topping>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Topping> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Topping> AddAsync(Topping topping, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Topping topping, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}
