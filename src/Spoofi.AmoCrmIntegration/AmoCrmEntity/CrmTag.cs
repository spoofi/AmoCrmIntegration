using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmTag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}