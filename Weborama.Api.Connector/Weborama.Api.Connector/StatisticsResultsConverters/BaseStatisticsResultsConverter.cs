using System.Collections.Generic;
using System.Linq;
using Ak.Framework.Core.Extensions;
using Newtonsoft.Json.Linq;
using Weborama.Api.Connector.Enums;
using Weborama.Api.Connector.Models.Statistics;

namespace Weborama.Api.Connector.StatisticsResultsConverters
{
    /// <summary>
    /// Конвертер результатов статистического отчета по событиям
    /// </summary>
    internal abstract class BaseStatisticsResultsConverter
    {
        #region Защищенные методы

        /// <summary>
        /// Получение элементов из метаданных
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="dimension">Измерение</param>
        /// <returns></returns>
        protected List<Item> GetMetadataItems(JObject obj, Dimension dimension)
        {
            List<Item> items = new List<Item>();

            JObject innerObject = obj["metadata"][dimension.ToStr().ToLower()].Value<JObject>();
            List<string> keys = innerObject.Properties().Select(p => p.Name).ToList();
            foreach (string key in keys)
                items.Add(new Item(key.ToInt32(), innerObject[key]["label"].Value<string>()));

            return items;
        }

        #endregion
    }
}
