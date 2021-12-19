using System;
using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Enums;
using Weborama.Api.Connector.Models.Statistics;
using Weborama.Api.Connector.StatisticsResultsConverters;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы со статистикой
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Statistics : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Statistics(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Statistics(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение статистического отчета
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <param name="dimensions">Измерения</param>
        /// <param name="metrics">Метрики</param>
        /// <returns></returns>
        public string GetStatistics(int accountId, DateTime startDate, DateTime endDate, IEnumerable<Enum> dimensions, IEnumerable<string> metrics)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/statistics.json?account_id={accountId}&start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&dimensions=[{GetStringFormatOfArray(dimensions)}]&metrics=[{GetStringFormatOfArray(metrics)}]");
            return GetDataFromApi(url);
        }

        /// <summary>
        /// Получение общего статистического отчета
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <returns></returns>
        public List<GeneralStatisticsItem> GetGeneralStatistics(int accountId, DateTime startDate, DateTime endDate)
        {
            string json = GetStatistics(
                accountId, 
                startDate, 
                endDate,
                new List<Enum> { Dimension.Campaign, Dimension.Ad_Space, Dimension.Insertion, Dimension.Creative }, 
                new List<string> { "click", "impression", "unique_click", "unique_impression", "conversion_nb_time_x_min", "conversion_rate_click", "conversion_rate_impression" });
            return new GeneralStatisticsResultsConverter().Convert(json, startDate, endDate);
        }

        /// <summary>
        /// Получение статистического отчета по событиям
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <returns></returns>
        public List<EventsStatisticsItem> GetEventsStatistics(int accountId, DateTime startDate, DateTime endDate)
        {
            string json = GetStatistics(accountId, startDate, endDate, new List<Enum> {Dimension.Campaign, Dimension.Ad_Space, Dimension.Insertion, Dimension.Creative, Dimension.Custom_Event}, new List<string> {"event"});
            return new EventsStatisticsResultsConverter().Convert(json, startDate, endDate);
        }

        #endregion
    }
}
