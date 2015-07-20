using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    /// <summary>
    ///     Тип задачи в CRM
    /// </summary>
    public class TaskType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}