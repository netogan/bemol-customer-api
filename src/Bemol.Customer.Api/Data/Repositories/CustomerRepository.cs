using Bemol.Customer.Api.Data.Context;
using Bemol.Customer.Api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bemol.Customer.Api.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Customer> GetCustomer(int id)
            => await _context.Customers.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<Domain.Models.Customer> AddCustomer(Domain.Models.Customer customer)
        {
            var customerCreated = _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return await GetCustomer(customer.Id);
        }

        public async Task<Domain.Models.Customer> UpdateCustomer(Domain.Models.Customer customer)
        {
            var customerExist = await GetCustomer(customer.Id);

            if (customerExist != null)
            {
                _context.Entry(customerExist).CurrentValues.SetValues(customer);
            }
            else
            {
                await AddCustomer(customer);
            }

            return await GetCustomer(customer.Id);
        }

        public async Task DeleteCustomer(int id)
        {
            var customerExist = await GetCustomer(id);

            if (customerExist != null)
            {
                _context.Customers.Remove(customerExist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
