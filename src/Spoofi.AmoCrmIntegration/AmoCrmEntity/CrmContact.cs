using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    public class CrmContact : IAmoCrmEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Last_modified")]
        public long LastModifiedTimestamp { get; set; }

        [JsonProperty("Account_id")]
        public long AccountId { get; set; }

        [JsonProperty("Responsible_user_id")]
        public long ResponsibleUserId { get; set; }

        [JsonProperty("Date_create")]
        public long DateCreateTimestamp { get; set; }

        [JsonProperty("Created_user_id")]
        public long CreatedUserId { get; set; }

        [JsonProperty("Linked_leads_id")]
        public List<long> LinkedLeadsId { get; set; }

        [JsonProperty("Tags")]
        public List<CrmTag> Tags { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Custom_fields")]
        //public List<CrmCustomField> CustomFields { get; set; }
        public object CustomFields { get; set; }

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