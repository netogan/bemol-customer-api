using Bemol.Customer.Api.Controllers.ViewModels;
using Bemol.Customer.Api.Data.Repositories.Interfaces;
using Bemol.Customer.Api.Domain.Services.Interfaces;

namespace Bemol.Customer.Api.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Models.Customer> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<Models.Customer> AddCustomer(AddCustomer addCustomer)
        {
            Models.Customer customer = new()
            {
                FirstName = addCustomer.FirstName,
                FullName = addCustomer.FullName,
                DocumentNumber = addCustomer.DocumentNumber,
                Email = addCustomer.Email,
                Address = addCustomer.Address,
                CreateAt = DateTime.Now,
                IsActive = true
            };

            return await _customerRepository.AddCustomer(customer);
        }

        public async Task<Models.Customer> UpdateCustomer(Models.Customer customer)
        {
            return await _customerRepository.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }
    }
}
