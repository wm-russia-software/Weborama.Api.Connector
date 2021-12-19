using System;
using Newtonsoft.Json;
using Weborama.Api.Connector.Converters;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Объект уровня Site/Offer
    /// </summary>
    public class Insertion
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
        /// Идентификатор рекламной сети
        /// </summary>
        [JsonProperty("ad_network_id")]
        public int AdNetworkId { get; set; }

        /// <summary>
        /// Идентификатор рекламного пространства
        /// </summary>
        [JsonProperty("ad_space_id")]
        public int AdSpaceId { get; set; }

        /// <summary>
        /// Идентификатор кампании
        /// </summary>
        [JsonProperty("campaign_id")]
        public int CampaignId { get; set; }

        /// <summary>
        /// Этап
        /// </summary>
        [JsonProperty("stage")]
        public string Stage { get; set; }

        /// <summary>
        /// Состояние
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// Уровень оптимизации
        /// </summary>
        [JsonProperty("optimization_level")]
        public string OptimizationLevel { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        [JsonProperty("comments")]
        public string Comments { get; set; }

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
        /// Признак ClickTag
        /// </summary>
        [JsonProperty("clicktag")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool ClickTag { get; set; }

        /// <summary>
        /// Тип оптимизации
        /// </summary>
        [JsonProperty("optimization_on")]
        public string OptimizationType { get; set; }

        /// <summary>
        /// Url лендинга
        /// </summary>
        [JsonProperty("landing_url")]
        public string LandingUrl { get; set; }

        /// <summary>
        /// Признак наличия большого количество размещений
        /// </summary>
        [JsonProperty("has_many_placements")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool HasManyPlacements { get; set; }

        /// <summary>
        /// Идентификатор формата доставки
        /// </summary>
        [JsonProperty("delivery_format_id")]
        public int DeliveryFormatId { get; set; }

        /// <summary>
        /// Признак того, что оплачивается публикующим
        /// </summary>
        [JsonProperty("publisher_paid")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsPublisherPaid { get; set; }

        /// <summary>
        /// Признак BID
        /// </summary>
        [JsonProperty("is_bid")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsBid { get; set; }

        /// <summary>
        /// Идентификатор группы размещения
        /// </summary>
        [JsonProperty("placement_group_id")]
        public int PlacementGroupId { get; set; }

        /// <summary>
        /// Признак включения оптимизации
        /// </summary>
        [JsonProperty("enable_optimization")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool EnableOptimization { get; set; }

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
        /// Признак наличия статистики
        /// </summary>
        [JsonProperty("has_statistics")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool HasStatistics { get; set; }

        #endregion
    }
}
