using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    /// <summary>
    ///     Тип примечания в CRM
    /// </summary>
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