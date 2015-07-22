using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class AddOrUpdateContactResponse : AmoCrmResponseBase<CrmAddOrUpdateContactResponseChild>
    {
        [JsonProperty("response")]
        public override CrmAddOrUpdateContactResponseChild Response { get; set; }
    }

    public class CrmAddOrUpdateContactResponseChild : IAmoCrmResponseChild
    {
        [JsonProperty("contacts")]
        public AddedOrUpdatedContacts Contacts { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }

    public class AddedOrUpdatedContacts
    {
        [JsonProperty("add")]
        public List<AddedContact> Add { get; set; }
    }

    public class AddedContact
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("request_id")]
        public long RequestId { get; set; }
    }
}