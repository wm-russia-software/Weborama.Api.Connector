using System;
using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с метриками
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Metrics : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Metrics(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Metrics(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка рекламных пространств
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="dimensions">Измерения</param>
        /// <returns></returns>
        public List<Metric> GetMetricsList(int accountId, IEnumerable<Enum> dimensions)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/dimensions/available_metrics.json?account_id={accountId}&dimensions=[{GetStringFormatOfArray(dimensions)}]");
            return GetDataFromApi<DataContainer<Metric>>(url).Values;
        }

        #endregion
    }
}
