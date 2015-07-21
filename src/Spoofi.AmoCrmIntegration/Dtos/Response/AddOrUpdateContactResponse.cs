using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class AddOrUpdateContactResponse : IAmoCrmResponse
    {
        [JsonProperty("response")]
        public CrmAddOrUpdateContactResponseDto Response { get; set; }
    }

    public class CrmAddOrUpdateContactResponseDto
    {
        [JsonProperty("contacts")]
        public AddedOrUpdatedContacts Contacts { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }
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