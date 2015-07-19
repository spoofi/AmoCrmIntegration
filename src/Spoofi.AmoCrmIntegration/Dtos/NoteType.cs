using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.Dtos
{
    public class NoteType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("editable")]
        public string Editable { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}