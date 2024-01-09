using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClimaQuente.Auxiliar
{
    public class Localização
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("country_code")]
        public string PaísCódigo { get; set; }

        [JsonProperty("country_name")]
        public string PaísNome{ get; set; }

        [JsonProperty("region_name")]
        public string RegiãoNome { get; set; }

        [JsonProperty("city_name")]
        public string CidadeNome { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("zip_code")]
        public string Cep { get; set; }

        [JsonProperty("time_zone")]
        public string UTC { get; set; }

        [JsonProperty("asn")]
        public string Asn { get; set; }

        [JsonProperty("as")]
        public string As { get; set; }

        [JsonProperty("is_proxy")]
        public bool ÚsaProxy { get; set; }
    }
}
