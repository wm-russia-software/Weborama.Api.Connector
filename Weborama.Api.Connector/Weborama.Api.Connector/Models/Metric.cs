using Newtonsoft.Json;
using Weborama.Api.Connector.Converters;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Метрика
    /// </summary>
    public class Metric
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
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Краткое название
        /// </summary>
        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        /// <summary>
        /// Человекочитабельное название
        /// </summary>
        [JsonProperty("human_name")]
        public string HumanName { get; set; }

        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// Идентификатор статической метрики
        /// </summary>
        [JsonProperty("static_metric_id")]
        public int? StaticMetricId { get; set; }

        /// <summary>
        /// Тип метрики
        /// </summary>
        [JsonProperty("metric_type")]
        public string MetricType { get; set; }

        /// <summary>
        /// Признак возможности вычисления среднего
        /// </summary>
        [JsonProperty("average_compute")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool AverageCompute { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Правило
        /// </summary>
        [JsonProperty("rule")]
        public string Rule { get; set; }

        /// <summary>
        /// Отображаемый тип
        /// </summary>
        [JsonProperty("display_type")]
        public string DisplayType { get; set; }

        /// <summary>
        /// Формула
        /// </summary>
        [JsonProperty("formula")]
        public string Formula { get; set; }

        /// <summary>
        /// Альтернативная формула
        /// </summary>
        [JsonProperty("alternative_formula")]
        public string AlternativeFormula { get; set; }

        #endregion
    }
}
