using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmLeadStatus : IAmoCrmEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("editable")]
        public string Editable { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}