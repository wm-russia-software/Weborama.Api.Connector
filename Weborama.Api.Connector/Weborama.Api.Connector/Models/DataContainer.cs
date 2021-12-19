using System.Collections.Generic;
using Newtonsoft.Json;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Контейнер данных
    /// </summary>
    internal class DataContainer<T>
    {
        #region Свойства

        /// <summary>
        /// Начальное значение
        /// </summary>
        [JsonProperty("start_index")]
        public int StartIndex { get; set; }

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        [JsonProperty("items_per_page")]
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Количество элементов
        /// </summary>
        [JsonProperty("total_result")]
        public int Total { get; set; }

        /// <summary>
        /// Элементы
        /// </summary>
        [JsonProperty("list")]
        public List<T> Values { get; set; }

        #endregion
    }
}
