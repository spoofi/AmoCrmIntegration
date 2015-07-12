using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Dtos;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Methods;

namespace Spoofi.AmoCrmIntegration.Service
{
    public class AmoCrmService : IAmoCrmService
    {
        private readonly AmoCrmConfig _crmConfig;

        public AmoCrmService(AmoCrmConfig crmConfig)
        {
            _crmConfig = crmConfig;
        }

        public CrmAccountInfo GetAccountInfo()
        {
            var accountInfo = AmoMethod.Get<CrmAccountInfoResponse>(_crmConfig.AccountCurrentUrl, _crmConfig);
            return accountInfo.Response.Account;
        }
    }
}