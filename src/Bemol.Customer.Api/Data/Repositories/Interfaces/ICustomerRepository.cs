namespace Bemol.Customer.Api.Data.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Domain.Models.Customer> GetCustomer(int id);
        Task<Domain.Models.Customer> AddCustomer(Domain.Models.Customer user);
        Task<Domain.Models.Customer> UpdateCustomer(Domain.Models.Customer user);
        Task DeleteCustomer(int id);
    }
}
