using Spoofi.AmoCrmIntegration.AmoCrmEntity;

namespace Spoofi.AmoCrmIntegration.Interface
{
    public interface IAmoCrmService
    {
        /// <summary>
        /// Получение информации об аккаунте в CRM
        /// </summary>
        /// <returns>Информация об аккаунте - <see cref="CrmAccountInfo"/></returns>
        CrmAccountInfo GetAccountInfo();
    }
}