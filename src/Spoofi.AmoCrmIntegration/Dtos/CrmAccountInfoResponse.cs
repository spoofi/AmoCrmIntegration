using Spoofi.AmoCrmIntegration.AmoCrmEntity;

namespace Spoofi.AmoCrmIntegration.Dtos
{
    public class CrmAccountInfoResponse
    {
        public CrmAccountInfoResponseDto Response { get; set; }
    }

    public class CrmAccountInfoResponseDto
    {
        public CrmAccountInfo Account { get; set; }
    }
}