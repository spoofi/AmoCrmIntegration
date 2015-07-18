using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.AmoCrmEntity
{
    /// <summary>
    ///     Пользователь в CRM
    /// </summary>
    public class CrmUser : IAmoCrmEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("rights_lead_add")]
        public string RightsLeadAdd { get; set; }

        [JsonProperty("rights_lead_view")]
        public string RightsLeadView { get; set; }

        [JsonProperty("rights_lead_edit")]
        public string RightsLeadEdit { get; set; }

        [JsonProperty("rights_lead_delete")]
        public string RightsLeadDelete { get; set; }

        [JsonProperty("rights_lead_export")]
        public string RightsLeadExport { get; set; }

        [JsonProperty("rights_contact_add")]
        public string RightsContactAdd { get; set; }

        [JsonProperty("rights_contact_view")]
        public string RightsContactView { get; set; }

        [JsonProperty("rights_contact_edit")]
        public string RightsContactEdit { get; set; }

        [JsonProperty("rights_contact_delete")]
        public string RightsContactDelete { get; set; }

        [JsonProperty("rights_contact_export")]
        public string RightsContactExport { get; set; }
    }
}