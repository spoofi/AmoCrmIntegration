using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Dtos.Response
{
    public class CrmResponseBase
    {
        private CrmGetAccountInfoResponse _crmGetAccountInfoResponse;

        public CrmResponseBase(CrmGetAccountInfoResponse crmGetAccountInfoResponse)
        {
            _crmGetAccountInfoResponse = crmGetAccountInfoResponse;
        }

        public string Error
        {
            get
            {
                if (_crmGetAccountInfoResponse.Response == null) throw new AmoCrmException(AmoCrmErrors.Unknown);
                return _crmGetAccountInfoResponse.Response.Error.HasValue() ? _crmGetAccountInfoResponse.Response.Error : null;
            }
        }
    }
}