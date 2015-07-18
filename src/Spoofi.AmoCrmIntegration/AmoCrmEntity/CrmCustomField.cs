using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmCustomField : IAmoCrmEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("values")]
        public List<CrmCustomFieldValue> Values { get; set; }
    }

    public class CrmCustomFieldValue
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enum")]
        public string @Enum { get; set; }

        [JsonProperty("last_modified")]
        public long LastModified { get; set; }
    }
}