using System;

namespace Spoofi.AmoCrmIntegration
{
    public class AmoCrmConfig
    {
        public AmoCrmConfig(string subdomain, string userLogin, string userHash, int? limitRows = 500, int? limitOffset = 0, DateTime? modifiedSince = null)
        {
            Subdomain = subdomain;
            UserLogin = userLogin;
            UserHash = userHash;
            LimitRows = limitRows;
            LimitOffset = limitOffset;
            ModifiedSince = modifiedSince;
        }

        public string Subdomain { get; set; }

        public string UserLogin { get; set; }

        public string UserHash { get; set; }

        public string AuthUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/auth.php?type=json", Subdomain); }
        }

        public string AccountCurrentUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/accounts/current?", Subdomain); }
        }

        public string TasksListUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/tasks/list?", Subdomain); }
        }

        public string ContactEventsListUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/notes/list?type=contact", Subdomain); }
        }

        public string LeadEventsListUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/notes/list?type=lead", Subdomain); }
        }

        public string UpdateTaskUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/tasks/set", Subdomain); }
        }

        public string ContactsListUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/contacts/list?", Subdomain); }
        }

        public string SetContactUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/contacts/set", Subdomain); }
        }

        public string ViewContactUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/contacts/edit.php?ID=", Subdomain); }
        }

        public string SetTaskUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/tasks/set", Subdomain); }
        }

        public string DealUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/api/v2/json/leads/list?", Subdomain); }
        }

        public string ViewDealUrl
        {
            get { return string.Format("https://{0}.amocrm.ru/private/deals/edit.php?ID=", Subdomain); }
        }

        public bool IsReady
        {
            get { return (!string.IsNullOrEmpty(UserHash) && UserLogin != null && Subdomain != null); } // TODO сделать экстеншен для строк, которыу будет проверять есть ли значение
        }

        public int? LimitRows { get; set; }

        public int? LimitOffset { get; set; }

        public DateTime? ModifiedSince { get; set; }
    }
}