using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class AmoCrmResponseBase : IAmoCrmResponse
    {
        public IAmoCrmResponseChild Response { get; set; }

        public string Error
        {
            get
            {
                if (Response == null) throw new AmoCrmException(AmoCrmErrors.Unknown);
                return Response.Error.HasValue() ? Response.Error : null;
            }
        }
    }
}