using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Spoofi.AmoCrmIntegration.Interface;
using Spoofi.AmoCrmIntegration.Misc;

namespace Spoofi.AmoCrmIntegration.Dtos.Request
{
    public class AddOrUpdateContactRequest : IAmoCrmRequest
    {
        [JsonProperty("request")]
        public AddOrUpdateContactObject Request { get; set; }
    }

    public class AddOrUpdateContactObject
    {
        [JsonProperty("contacts")]
        public AddOrUpdateCrmContacts Contacts { get; set; }
    }

    public class AddOrUpdateCrmContacts
    {
        [JsonProperty("add", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<AddOrUpdateCrmContact> Add { get; set; }

        [JsonProperty("update", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<AddOrUpdateCrmContact> Update { get; set; }
    }

    public class AddOrUpdateCrmContact
    {
        /// <summary>
        ///     Идентификатор обновляемого контакта
        /// </summary>
        [JsonProperty("id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long Id { get; set; }

        /// <summary>
        ///     Имя контакта
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Уникальный идентификатор записи в клиентской программе (не обязательный параметр)
        /// </summary>
        [JsonProperty("request_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long RequestId { get; set; }

        [JsonProperty("date_create", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long? DateCreateTimestamp
        {
            get { return DateCreate.GetTimestamp(); }
            set { DateCreate = value.GetDateTime(); }
        }

        /// <summary>
        ///     Дата создания контакта (не обязательный параметр)
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreate { get; set; }

        [JsonProperty("last_modified")]
        public long? LastModifiedTimestamp
        {
            get { return LastModified.GetTimestamp() ?? DateTime.Now.GetTimestamp(); }
            set { LastModified = value.GetDateTime(); }
        }

        /// <summary>
        ///     Дата последнего изменения контакта (не обязательный параметр)
        /// </summary>
        [JsonIgnore]
        public DateTime? LastModified { get; set; }

        /// <summary>
        ///     Уникальный идентификатор ответственного пользователя
        /// </summary>
        [JsonProperty("responsible_user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ResponsibleUserId { get; set; }

        /// <summary>
        ///     Список уникальных идентификаторов связанных сделок
        /// </summary>
        [JsonProperty("linked_leads_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<long> LinkedLeadsIds { get; set; }

        /// <summary>
        ///     Имя компании контакта
        /// </summary>
        [JsonProperty("company_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CompanyName { get; set; }

        /// <summary>
        ///     Название тегов через запятую
        /// </summary>
        [JsonProperty("tags", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Tags { get; set; }

        /// <summary>
        ///     Дополнительные поля контакта
        /// </summary>
        [JsonProperty("custom_fields", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<AddContactCustomField> CustomFields { get; set; }
    }

    public class AddContactCustomField
    {
        public long Id { get; set; }

        public AddContactCustomFieldValues Values { get; set; }
    }

    public class AddContactCustomFieldValues
    {
        public string Value { get; set; }

        public string Enum { get; set; }
    }
}