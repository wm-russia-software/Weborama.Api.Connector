using System;
using Newtonsoft.Json;
using Weborama.Api.Connector.Converters;
using Weborama.Api.Connector.Enums;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Кампания
    /// </summary>
    public class Campaign
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
        /// Этап
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

        /// <summary>
        /// Идентификатор агентства
        /// </summary>
        [JsonProperty("agency_id")]
        public int AgencyId { get; set; }

        /// <summary>
        /// Идентификатор типа канала
        /// </summary>
        [JsonProperty("channel_id")]
        public int ChannelTypeId { get; set; }

        /// <summary>
        /// Тип канала
        /// </summary>
        public ChannelType? ChannelType => ChannelTypeId > 0 ? (ChannelType)ChannelTypeId : (ChannelType?)null;

        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

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
        /// Признак отображения
        /// </summary>
        [JsonProperty("is_visible")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Часовой пояс
        /// </summary>
        [JsonProperty("timezone_name")]
        public string Timezone { get; set; }

        /// <summary>
        /// Дата начала
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Реальная дата начала
        /// </summary>
        [JsonProperty("real_start_date")]
        public DateTime? RealStartDate { get; set; }

        /// <summary>
        /// Эффективная дата начала
        /// </summary>
        [JsonProperty("effective_start_date")]
        public string EffectiveStartDate { get; set; }

        /// <summary>
        /// Конечная дата
        /// </summary>
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Реальная конечная дата
        /// </summary>
        [JsonProperty("real_end_date")]
        public DateTime? RealEndDate { get; set; }

        /// <summary>
        /// Эффективная конечная дата
        /// </summary>
        [JsonProperty("effective_end_date")]
        public DateTime? EffectiveEndDate { get; set; }

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
        /// Признак автоматической даты начала
        /// </summary>
        [JsonProperty("is_auto_start_date")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsAutoStartDate { get; set; }

        /// <summary>
        /// Признак остановки отображения после конечной даты
        /// </summary>
        [JsonProperty("stop_display_after_end_date")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool StopDisplayAfterEndDate { get; set; }

        /// <summary>
        /// Признак автозавершения
        /// </summary>
        [JsonProperty("is_auto_end_date")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsAutoEndDate { get; set; }

        /// <summary>
        /// Количество дней отслеживания PostClick
        /// </summary>
        [JsonProperty("postclick_tracking_days")]
        public int PostClickTrackingDays { get; set; }

        /// <summary>
        /// Количество дней отслеживания PostImpression
        /// </summary>
        [JsonProperty("postimpression_tracking_days")]
        public int PostImpressionTrackingDays { get; set; }

        /// <summary>
        /// Количество дней отслеживания PostView
        /// </summary>
        [JsonProperty("postview_tracking_days")]
        public int PostViewTrackingDays { get; set; }

        /// <summary>
        /// Количество дней отслеживания PostEvent
        /// </summary>
        [JsonProperty("postevent_tracking_days")]
        public int PostEventTrackingDays { get; set; }

        /// <summary>
        /// Признак активации OBA
        /// </summary>
        [JsonProperty("is_oba_activated")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsObaActivated { get; set; }

        /// <summary>
        /// Признак видимости в Wam
        /// </summary>
        [JsonProperty("is_visible_in_wam")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsVisibleInWam { get; set; }

        /// <summary>
        /// Url лендинга
        /// </summary>
        [JsonProperty("landing_url")]
        public string LandingUrl { get; set; }

        /// <summary>
        /// Признак активации видимости
        /// </summary>
        [JsonProperty("is_visibility_activated")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsVisibilityActivated { get; set; }

        /// <summary>
        /// Признак активации строителя Url
        /// </summary>
        [JsonProperty("is_url_builder_activated")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsUrlBuilderActivated { get; set; }

        /// <summary>
        /// Идентификатор продукта и бренда
        /// </summary>
        [JsonProperty("brand_and_product_id")]
        public int BrandAndProductId { get; set; }

        /// <summary>
        /// Признак наличия статистики
        /// </summary>
        [JsonProperty("has_statistics")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool HasStatistics { get; set; }

        #endregion
    }
}
