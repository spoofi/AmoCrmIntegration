using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RestSharp;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;
using Spoofi.AmoCrmIntegration.Dtos;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Methods;
using Spoofi.AmoCrmIntegration.Misc;

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
            if (accountInfo == null || accountInfo.Response == null)
                throw new AmoCrmException(AmoCrmErrors.Unknown);
            return accountInfo.Response.Account;
        }

        public IEnumerable<CrmContact> GetAllContacts()
        {
            var contacts = new List<CrmContact>();
            for (var offset = 0; ; offset += _crmConfig.LimitRows ?? 500)
            {
                _crmConfig.LimitOffset = offset;
                var contactsList = AmoMethod.Get<CrmContactResponse>(_crmConfig.ContactsListUrl, _crmConfig);
                if (contactsList == null)
                    break;
                contacts.AddRange(contactsList.Response.Contacts);
            }
            return contacts;
        }

        public CrmContact GetContact(long contactId)
        {
            var parameterId = new Parameter { Name = "id", Value = contactId, Type = ParameterType.QueryString };
            var contact = AmoMethod.Get<CrmContactResponse>(_crmConfig.ContactsListUrl, _crmConfig, parameterId);
            return contact.Response.Contacts.FirstOrDefault();
        }
    }
}