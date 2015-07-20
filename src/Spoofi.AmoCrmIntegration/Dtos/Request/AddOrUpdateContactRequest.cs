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
        public AddOrUpdateCrmContactDto Contacts { get; set; }
    }

    public class AddOrUpdateCrmContactDto
    {
        [JsonProperty("add")]
        public List<AddCrmContact> Add { get; set; }

        [JsonProperty("update")]
        public List<UpdateCrmContact> Update { get; set; }
    }

    public class AddCrmContact
    {
        /// <summary>
        ///     Имя создаваемого контакта
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Уникальный идентификатор записи в клиентской программе (не обязательный параметр)
        /// </summary>
        [JsonProperty("request_id")]
        public long RequestId { get; set; }

        [JsonProperty("date_create")]
        public long? DateCreateTimestamp { get; set; }

        /// <summary>
        ///     Дата создания контакта (не обязательный параметр)
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreate
        {
            get { return DateCreateTimestamp.GetDateTime(); }
            set { DateCreateTimestamp = value.GetTimestamp(); }
        }

        [JsonProperty("last_modified")]
        public long? LastModifiedTimestamp { get; set; }

        /// <summary>
        ///     Дата последнего изменения контакта (не обязательный параметр)
        /// </summary>
        [JsonIgnore]
        public DateTime? LastModified
        {
            get { return LastModifiedTimestamp.GetDateTime(); }
            set { LastModifiedTimestamp = value.GetTimestamp(); }
        }

        /// <summary>
        ///     Уникальный идентификатор ответственного пользователя
        /// </summary>
        [JsonProperty("responsible_user_id")]
        public long ResponsibleUserId { get; set; }

        /// <summary>
        ///     Список уникальных идентификаторов связанных сделок
        /// </summary>
        [JsonProperty("linked_leads_id")]
        public List<long> LinkedLeadsIds { get; set; }

        /// <summary>
        ///     Имя компании контакта
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        /// <summary>
        ///     Название тегов через запятую
        /// </summary>
        [JsonProperty("tags")]
        public string Tags { get; set; }


    }

    public class UpdateCrmContact
    {
    }
}