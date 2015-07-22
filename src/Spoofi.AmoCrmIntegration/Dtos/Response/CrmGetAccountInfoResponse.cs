using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class CrmGetAccountInfoResponse : AmoCrmResponseBase
    {
        [JsonProperty("response")]
        public new CrmAccountInfoResponseChild Response { get; set; }
      
    }

    public class CrmAccountInfoResponseChild : IAmoCrmResponseChild
    {
        [JsonProperty("account")]
        public CrmAccountInfo Account { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}