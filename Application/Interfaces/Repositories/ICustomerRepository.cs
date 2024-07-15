using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        public Task<Customer> AddCustomer(Customer customer);
        public Task<IEnumerable<Customer>> GetAllOnboardedCustomers();
        public Task<Customer> GetCustomerByPhoneNumber(string phoneNumber);
        public Task<bool> VerifyPhoneNumber(string phoneNumber);
        public Task SaveChangesAsync();
    }
}
