using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class CrmGetContactResponse : AmoCrmResponseBase<CrmContactResponseChild>
    {
        public override CrmContactResponseChild Response { get; set; }
    }

    public class CrmContactResponseChild : IAmoCrmResponseChild
    {
        [JsonProperty("contacts")]
        public List<CrmContact> Contacts { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}