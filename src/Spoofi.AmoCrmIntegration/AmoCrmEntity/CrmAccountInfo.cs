using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Dtos;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    /// <summary>
    ///     Информация об аккаунте CRM
    /// </summary>
    public class CrmAccountInfo : IAmoCrmEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subdomain")]
        public string Subdomain { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("paid_from")]
        public string PaidFrom { get; set; } // UNIX TimeStamp (int/long)

        [JsonProperty("paid_till")]
        public string PaidTill { get; set; } // or 'false' (bool), if the account is not paid

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("date_pattern")]
        public string DatePattern { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("users")]
        public List<CrmUser> Users { get; set; }

        [JsonProperty("leads_statuses")]
        public List<CrmLeadStatus> LeadsStatuses { get; set; }

        [JsonProperty("custom_fields")]
        public AccountInfoCustomFields CustomFields { get; set; }

        [JsonProperty("note_types")]
        public List<NoteType> NoteTypes { get; set; }

        [JsonProperty("task_types")]
        public List<TaskType> TaskTypes { get; set; }
    }
}