using System.Text.Json.Serialization;

namespace Bemol.Customer.Api.Integrations.External.ViaCep.Models
{
    public class ZipCodeResponse
    {
        [JsonPropertyName("cep")]
        public string Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }

        [JsonPropertyName("complemento")]
        public string Complemento { get; set; }

        [JsonPropertyName("unidade")]
        public string Unidade { get; set; }

        [JsonPropertyName("bairro")]
        public string Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string Uf { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }

        [JsonPropertyName("regiao")]
        public string Regiao { get; set; }

        [JsonPropertyName("ibge")]
        public long Ibge { get; set; }

        [JsonPropertyName("gia")]
        public string Gia { get; set; }

        [JsonPropertyName("ddd")]
        public long Ddd { get; set; }

        [JsonPropertyName("siafi")]
        public long Siafi { get; set; }
    }
}
