using Bemol.Customer.Api.Integrations.External.ViaCep.Models;

namespace Bemol.Customer.Api.Integrations.External.ViaCep.Interfaces
{
    public interface IViaCepService
    {
        Task<ZipCodeResponse> GetZipCode(int zipCode);
    }
}
