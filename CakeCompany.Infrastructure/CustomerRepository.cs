using CakeCompany.Core.Entity;
using CakeCompany.Core.Interfaces.Repositories;
using CakeCompany.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CakeCompany.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CakeCompanyContext _context;

        public CustomerRepository(CakeCompanyContext context)
        {
            _context = context;
        }

        private async Task<bool> CustomerExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Customers.ToListAsync(ct);
        }

        public async Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken))
        {
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync(ct);
            return newCustomer;
        }

        public async Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken))
        {
            if (!await CustomerExists(customer.Id, ct))
                return false;
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await CustomerExists(id, ct))
                return false;
            var toRemove = _context.Customers.Find(id);
            _context.Customers.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public  Customer GetByIdentityId(string id)
        {
            return _context.Customers.Where(x => x.IdentityId == id).FirstOrDefault();
        }
    }
}
