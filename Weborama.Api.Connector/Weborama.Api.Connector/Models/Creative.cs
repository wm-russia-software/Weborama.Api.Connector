using System;
using Newtonsoft.Json;
using Weborama.Api.Connector.Converters;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Креатив
    /// </summary>
    public class Creative
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
        /// Состояние
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

        /// <summary>
        /// Идентификатор конкретного креатива
        /// </summary>
        [JsonProperty("distinct_creative_id")]
        public int DistinctCreativeId { get; set; }

        /// <summary>
        /// Идентификатор формата креатива
        /// </summary>
        [JsonProperty("creative_format_id")]
        public int CreativeFormatId { get; set; }

        /// <summary>
        /// Идентификатор конкретного аккаунта
        /// </summary>
        [JsonProperty("distinct_account_id")]
        public int DistinctAccountId { get; set; }

        /// <summary>
        /// Идентификатор live версии креатива
        /// </summary>
        [JsonProperty("live_creative_version_id")]
        public int LiveCreativeVersionId { get; set; }

        /// <summary>
        /// Идентификатор последней версии креатива
        /// </summary>
        [JsonProperty("latest_creative_version_id")]
        public int LatestCreativeVersionId { get; set; }

        /// <summary>
        /// Идентификаторы позиции
        /// </summary>
        [JsonProperty("ad_position_ids")]
        public string AdPositionIds { get; set; }

        /// <summary>
        /// Идентификатор папки
        /// </summary>
        [JsonProperty("folder_id")]
        public int FolderId { get; set; }

        /// <summary>
        /// Признак наличия в CMS
        /// </summary>
        [JsonProperty("is_ad_cms")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsAdCms { get; set; }

        /// <summary>
        /// Метка предпросмотра
        /// </summary>
        [JsonProperty("previewer_label")]
        public string PreviewerLabel { get; set; }

        /// <summary>
        /// Признак DCO
        /// </summary>
        [JsonProperty("is_dco")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsDco { get; set; }

        /// <summary>
        /// Признак включения live автообновления
        /// </summary>
        [JsonProperty("live_autoupdate")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool LiveAutoupdate { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        [JsonProperty("settings")]
        public string Settings { get; set; }

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

        /// <summary>
        /// Признак наличия статистики
        /// </summary>
        [JsonProperty("has_statistics")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool HasStatistics { get; set; }

        #endregion
    }
}
