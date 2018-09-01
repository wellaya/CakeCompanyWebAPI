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
    public class CakeOrderRepository : ICakeOrderRepository
    {
        private readonly CakeCompanyContext _context;

        public CakeOrderRepository(CakeCompanyContext context)
        {
            _context = context;
        }

        private async Task<bool> CakeOrderExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<CakeOrder>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.CakeOrders.ToListAsync(ct);
        }

        public async Task<CakeOrder> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.CakeOrders.FindAsync(id);
        }

        public async Task<CakeOrder> AddAsync(CakeOrder cakeOrder, CancellationToken ct = default(CancellationToken))
        {
            _context.CakeOrders.Add(cakeOrder);
            await _context.SaveChangesAsync(ct);
            return cakeOrder;
        }

        public async Task<bool> UpdateAsync(CakeOrder cakeOrder, CancellationToken ct = default(CancellationToken))
        {
            if (!await CakeOrderExists(cakeOrder.Id, ct))
                return false;
            _context.CakeOrders.Update(cakeOrder);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await CakeOrderExists(id, ct))
                return false;
            var toRemove = _context.CakeOrders.Find(id);
            _context.CakeOrders.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}
