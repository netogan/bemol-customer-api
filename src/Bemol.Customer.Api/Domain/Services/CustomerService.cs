using AutoMapper;
using Bemol.Customer.Api.Controllers.ViewModels;
using Bemol.Customer.Api.Data.Repositories.Interfaces;
using Bemol.Customer.Api.Domain.Services.Interfaces;
using Bemol.Customer.Api.Integrations.External.ViaCep.Interfaces;

namespace Bemol.Customer.Api.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        public readonly ICustomerRepository _customerRepository;
        public readonly IViaCepService _viaCepService;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IViaCepService viaCepService, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _viaCepService = viaCepService;
            _mapper = mapper;
        }
        public async Task<Models.Customer> GetCustomer(int id)
        {
            return await _customerRepository.GetCustomer(id);
        }

        public async Task<Models.Customer> AddCustomer(AddCustomer addCustomer)
        {
            var customer = _mapper.Map<Models.Customer>(addCustomer);

            var zipCodeInfo = await _viaCepService.GetZipCode(customer.ZipCode);

            if (string.IsNullOrWhiteSpace(zipCodeInfo.Logradouro))
                return null;

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
