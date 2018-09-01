using CakeCompany.Core.Entity;
using CakeCompany.Core.Interfaces.Repositories;
using CakeCompany.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Infrastructure
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly CakeCompanyContext _context;

        public ToppingRepository(CakeCompanyContext context)
        {
            _context = context;
        }

        private async Task<bool> ToppingExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Topping>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Toppings.ToListAsync(ct);
        }

        public async Task<Topping> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Toppings.FindAsync(id);
        }

        public async Task<Topping> AddAsync(Topping topping, CancellationToken ct = default(CancellationToken))
        {
            _context.Toppings.Add(topping);
            await _context.SaveChangesAsync(ct);
            return topping;
        }

        public async Task<bool> UpdateAsync(Topping topping, CancellationToken ct = default(CancellationToken))
        {
            if (!await ToppingExists(topping.Id, ct))
                return false;
            _context.Toppings.Update(topping);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await ToppingExists(id, ct))
                return false;
            var toRemove = _context.Toppings.Find(id);
            _context.Toppings.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
