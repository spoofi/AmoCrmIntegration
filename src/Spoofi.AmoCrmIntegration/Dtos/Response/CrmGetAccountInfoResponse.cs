using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class CrmGetAccountInfoResponse : AmoCrmResponseBase<CrmAccountInfoResponseChild>
    {
        [JsonProperty("response")]
        public override CrmAccountInfoResponseChild Response { get; set; }
    }

    public class CrmAccountInfoResponseChild : IAmoCrmResponseChild
    {
        [JsonProperty("account")]
        public CrmAccountInfo Account { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}