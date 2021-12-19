using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с рекламным сетями
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class AdNetworks : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public AdNetworks(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public AdNetworks(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка рекламных сетей
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns></returns>
        public List<AdNetwork> GetAdNetworksList(int accountId)
        {
            List<AdNetwork> result = new List<AdNetwork>();

            int limit = 1000;
            int offset = 0;
            DataContainer<AdNetwork> container = GetAdNetworks(accountId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetAdNetworks(accountId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;

        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка рекламных сетей
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<AdNetwork> GetAdNetworks(int accountId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/ad_networks.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<AdNetwork>>(url);
        }

        #endregion
    }
}
