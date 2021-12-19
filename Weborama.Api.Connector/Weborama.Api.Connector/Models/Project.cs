using System;
using Newtonsoft.Json;
using Weborama.Api.Connector.Converters;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Проект
    /// </summary>
    public class Project
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
        /// Признак отображения проекта
        /// </summary>
        [JsonProperty("is_visible")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Признак принадлежности к Yandex
        /// </summary>
        [JsonProperty("is_yandex")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool IsYandex { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

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
