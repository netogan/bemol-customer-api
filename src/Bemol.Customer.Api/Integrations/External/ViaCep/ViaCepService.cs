using Bemol.Customer.Api.Integrations.External.ViaCep.Interfaces;
using Bemol.Customer.Api.Integrations.External.ViaCep.Models;
using RestSharp;

namespace Bemol.Customer.Api.Integrations.External.ViaCep
{
    public class ViaCepService(IConfiguration configuration, RestClient client) : IViaCepService
    {
        public async Task<ZipCodeResponse> GetZipCode(int zipCode)
        {
            var baseUrl = configuration.GetSection("ViaCep:UrlBase").Value;

            var request = new RestRequest($"{baseUrl}/ws/{zipCode}/json", Method.Get);

            var zipCodeInfo = await client.GetAsync<ZipCodeResponse>(request);

            return zipCodeInfo!;
        }
    }
}
