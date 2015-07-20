using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Interface;

namespace Spoofi.AmoCrmIntegration.Dtos
{
    public class CrmGetAccountInfoResponse : IAmoCrmGetResponse
    {
        public CrmAccountInfoResponseDto Response { get; set; }
    }

    public class CrmAccountInfoResponseDto
    {
        public CrmAccountInfo Account { get; set; }
    }
}