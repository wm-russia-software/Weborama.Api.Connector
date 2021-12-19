using System;
using Ak.Framework.Core.Helpers;
using Newtonsoft.Json;
using Weborama.Api.Connector.Enums;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Рекламное пространство
    /// </summary>
    public class AdSpace
    {
        #region Свойства

        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [JsonProperty("label")]
        public string Name { get; set; }

        /// <summary>
        /// Тип рекламного пространства
        /// </summary>
        [JsonProperty("ad_space_type")]
        public string AdSpaceType { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

        /// <summary>
        /// Внешний идентификатор
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Внешнее название
        /// </summary>
        [JsonProperty("external_name")]
        public string ExternalName { get; set; }

        /// <summary>
        /// Почтовые ящики
        /// </summary>
        [JsonProperty("emails")]
        public string Emails { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Url сайта
        /// </summary>
        [JsonProperty("site_url")]
        public string SiteUrl { get; set; }

        /// <summary>
        /// Путь BurstPath
        /// </summary>
        [JsonProperty("burstpath")]
        public string BurstPath { get; set; }

        /// <summary>
        /// Тип BurstType
        /// </summary>
        [JsonProperty("bursttype")]
        public string BurstType { get; set; }

        /// <summary>
        /// ZIndex
        /// </summary>
        [JsonProperty("zindex")]
        public int ZIndex { get; set; }

        /// <summary>
        /// Идентификатор страны
        /// </summary>
        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        /// <summary>
        /// Идентификатор рекламной сервера
        /// </summary>
        [JsonProperty("ad_server_id")]
        public int AdServerId { get; set; }

        /// <summary>
        /// Идентификатор рекламной сети
        /// </summary>
        [JsonProperty("ad_network_id")]
        public int AdNetworkId { get; set; }

        /// <summary>
        /// Идентификатор типа канала
        /// </summary>
        [JsonProperty("channel_id")]
        public int ChannelTypeId { get; set; }

        /// <summary>
        /// Тип канала
        /// </summary>
        public ChannelType? ChannelType => ChannelTypeId > 0 ? (ChannelType) ChannelTypeId : (ChannelType?) null;

        /// <summary>
        /// Дата создания
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        [JsonProperty("deleted_at")]
        public DateTime? Deleted { get; set; }
        
        #endregion
    }
}
