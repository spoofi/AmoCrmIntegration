using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmAccountInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Subdomain { get; set; }

        public string Currency { get; set; }

        [JsonProperty("Paid_from")]
        public string PaidFrom { get; set; } // UNIX TimeStamp (int/long)

        [JsonProperty("Paid_till")]
        public string PaidTill { get; set; } // or 'false' (bool), if the account is not paid

        public string Timezone { get; set; }

        [JsonProperty("Date_pattern")]
        public string DatePattern { get; set; }

        public string Language { get; set; }

        public List<object> Users { get; set; }

        [JsonProperty("Leads_statuses")]
        public List<object> LeadsStatuses { get; set; }

        [JsonProperty("Custom_fields")]
        public object CustomFields { get; set; }

        [JsonProperty("Note_types")]
        public List<object> NoteTypes { get; set; }

        [JsonProperty("Task_types")]
        public List<object> TaskTypes { get; set; }

        /*public List<CrmUser> Users { get; set; }
        
        public List<LeadsStatus> Leads_statuses { get; set; }

        public CustomFields Custom_fields { get; set; }

        public List<NoteType> Note_types { get; set; }
        
        public List<TaskType> Task_types { get; set; }*/
    }
}