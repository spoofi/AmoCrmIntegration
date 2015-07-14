using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmTag
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}