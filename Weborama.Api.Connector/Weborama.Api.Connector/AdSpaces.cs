using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с рекламным пространствам
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class AdSpaces : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public AdSpaces(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public AdSpaces(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка рекламных пространств
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns></returns>
        public List<AdSpace> GetAdSpacesList(int accountId)
        {
            List<AdSpace> result = new List<AdSpace>();

            int limit = 1000;
            int offset = 0;
            DataContainer<AdSpace> container = GetAllAdSpaces(accountId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetAllAdSpaces(accountId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        /// <summary>
        /// Получение списка рекламных пространств
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="campaignId">Идентификатор кампании</param>
        /// <returns></returns>
        public List<AdSpace> GetAdSpacesList(int accountId, int campaignId)
        {
            List<AdSpace> result = new List<AdSpace>();

            int limit = 500;
            int offset = 0;
            DataContainer<AdSpace> container = GetAdSpaces(accountId, campaignId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetAdSpaces(accountId, campaignId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка рекламных пространств
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="campaignId">Идентификатор кампании</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<AdSpace> GetAdSpaces(int accountId, int campaignId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/campaigns/{campaignId}/ad_spaces.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<AdSpace>>(url);
        }

        /// <summary>
        /// Получение списка всех рекламных пространств
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<AdSpace> GetAllAdSpaces(int accountId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/ad_spaces.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<AdSpace>>(url);
        }

        #endregion
    }
}
