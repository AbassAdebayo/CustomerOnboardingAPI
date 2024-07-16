using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllOnboardedCustomers()
        {
            return await _context.Customers.Where(c => c.IsVerified)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByPhoneNumber(string phoneNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<bool> CustomerExistsByEmail(string email)
        {
            return await _context.Customers.AnyAsync(c => c.Email == email);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
