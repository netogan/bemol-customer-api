using Bemol.Customer.Api.Controllers.ViewModels;

namespace Bemol.Customer.Api.Domain.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Models.Customer> GetCustomer(int id);
        Task<Models.Customer> AddCustomer(AddCustomer addCustomer);
        Task<Models.Customer> UpdateCustomer(Models.Customer customer);
        Task DeleteCustomer(int id);
    }
}
