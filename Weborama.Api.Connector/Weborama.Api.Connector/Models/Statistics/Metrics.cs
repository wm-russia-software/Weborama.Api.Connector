using Newtonsoft.Json;

namespace Weborama.Api.Connector.Models.Statistics
{
    /// <summary>
    /// Класс-контейнер для метрик
    /// </summary>
    public class Metrics
    {
        #region Свойства

        /// <summary>
        /// Клики
        /// </summary>
        [JsonProperty("click")]
        public int? Clicks { get; private set; }

        /// <summary>
        /// Показы
        /// </summary>
        [JsonProperty("impression")]
        public int? Impressions { get; private set; }

        /// <summary>
        /// Уникальные клики
        /// </summary>
        [JsonProperty("unique_click")]
        public int? UniqueClicks { get; private set; }

        /// <summary>
        /// Уникальные показы
        /// </summary>
        [JsonProperty("unique_impression")]
        public int? UniqueImpressions { get; private set; }

        /// <summary>
        /// Количество конверсий меньше, чем за 60 минут
        /// </summary>
        [JsonProperty("conversion_nb_time_x_min")]
        public decimal? ConversionsInLessThan60Minutes { get; private set; }

        /// <summary>
        /// Процент конверсии кликов
        /// </summary>
        [JsonProperty("conversion_rate_click")]
        public decimal? ClicksConversionRate { get; private set; }

        /// <summary>
        /// Процент конверсии показов
        /// </summary>
        [JsonProperty("conversion_rate_impression")]
        public decimal? ImpressionsConversionRate { get; private set; }

        #endregion
    }
}
