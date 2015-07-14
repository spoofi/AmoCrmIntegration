using System.Collections.Generic;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;

namespace Spoofi.AmoCrmIntegration.Dtos
{
    public class CrmContactResponse
    {
        public CrmContactResponseDto Response { get; set; }
    }

    public class CrmContactResponseDto
    {
        public List<CrmContact> Contacts { get; set; }
    }
}