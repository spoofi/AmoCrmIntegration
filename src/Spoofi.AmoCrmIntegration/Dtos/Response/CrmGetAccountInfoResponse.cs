using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class CrmGetAccountInfoResponse : IAmoCrmResponse
    {
        public CrmAccountInfoResponseDto Response { get; set; }
    }

    public class CrmAccountInfoResponseDto
    {
        public CrmAccountInfo Account { get; set; }
    }
}