using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с объектами Sites/Offers
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Insertions : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Insertions(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Insertions(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка объектов Sites/Offers
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="campaignId">Идентификатор кампании</param>
        /// <returns></returns>
        public List<Insertion> GetInsertionsList(int accountId, int campaignId)
        {
            List<Insertion> result = new List<Insertion>();

            int limit = 2000;
            int offset = 0;
            DataContainer<Insertion> container = GetInsertions(accountId, campaignId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetInsertions(accountId, campaignId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        /// <summary>
        /// Получение списка объектов Sites/Offers
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns></returns>
        public List<Insertion> GetInsertionsList(int accountId)
        {
            List<Insertion> result = new List<Insertion>();

            int limit = 10000;
            int offset = 0;
            DataContainer<Insertion> container = GetAllInsertions(accountId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetAllInsertions(accountId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка объектов Sites/Offers
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="campaignId">Идентификатор кампании</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Insertion> GetInsertions(int accountId, int campaignId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/campaigns/{campaignId}/insertions.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Insertion>>(url);
        }

        /// <summary>
        /// Получение списка объектов Sites/Offers
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Insertion> GetAllInsertions(int accountId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/insertions.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Insertion>>(url);
        }


        #endregion
    }
}
