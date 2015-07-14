using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmContact
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Last_modified")]
        public long LastModifiedTimestamp { get; set; }

        [JsonProperty("Account_id")]
        public int AccountId { get; set; }

        [JsonProperty("Responsible_user_id")]
        public int ResponsibleUserId { get; set; }

        [JsonProperty("Date_create")]
        public long DateCreateTimestamp { get; set; }

        [JsonProperty("Created_user_id")]
        public string CreatedUserId { get; set; }

        [JsonProperty("Linked_leads_id")]
        public List<string> LinkedLeadsId { get; set; }

        [JsonProperty("Tags")]
        public List<CrmTag> Tags { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Custom_fields")]
        public List<CrmCustomField> CustomFields { get; set; }

        public DateTime DateCreate
        {
            get { return DateCreateTimestamp.GetDateTime(); }
            set { DateCreateTimestamp = value.GetTimestamp(); }
        }

        public DateTime LastModified
        {
            get { return LastModifiedTimestamp.GetDateTime(); }
            set { LastModifiedTimestamp = value.GetTimestamp(); }
        }
    }
}