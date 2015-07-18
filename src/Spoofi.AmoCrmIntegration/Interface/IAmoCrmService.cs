using System.Collections.Generic;
using Spoofi.AmoCrmIntegration.AmoCrmEntity;

namespace Spoofi.AmoCrmIntegration.Interface
{
    public interface IAmoCrmService
    {
        /// <summary>
        ///     Получение информации об аккаунте в CRM
        /// </summary>
        /// <returns>Информация об аккаунте - <see cref="CrmAccountInfo" /></returns>
        CrmAccountInfo GetAccountInfo();

        /// <summary>
        ///     Получение пользователей из CRM
        /// </summary>
        /// <returns></returns>
        IEnumerable<CrmUser> GetCrmUsers();

        /// <summary>
        ///     Получить все контакты из CRM
        /// </summary>
        /// <returns></returns>
        IEnumerable<CrmContact> GetContacts();

        /// <summary>
        ///     Получить все контакты из CRM по запросу
        /// </summary>
        /// <returns></returns>
        IEnumerable<CrmContact> GetContacts(string query);

        /// <summary>
        ///     Получить все контакты из CRM по id ответственного пользователя
        /// </summary>
        /// <returns></returns>
        IEnumerable<CrmContact> GetContacts(long responsibleUserId);

        /// <summary>
        ///     Получить контакт по id
        /// </summary>
        /// <param name="contactId">id контакта</param>
        /// <returns>
        ///     <see cref="CrmContact" />
        /// </returns>
        CrmContact GetContact(long contactId);
    }
}