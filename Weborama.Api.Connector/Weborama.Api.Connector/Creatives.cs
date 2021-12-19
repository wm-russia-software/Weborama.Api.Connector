using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с креативами
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Creatives : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Creatives(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Creatives(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка креативов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="insertionId">Идентификатор объекта Sites/Offers</param>
        /// <returns></returns>
        public List<Creative> GetCreativesList(int accountId, int insertionId)
        {
            List<Creative> result = new List<Creative>();

            int limit = 500;
            int offset = 0;
            DataContainer<Creative> container = GetCreatives(accountId, insertionId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetCreatives(accountId, insertionId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        /// <summary>
        /// Получение списка креативов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns></returns>
        public List<Creative> GetCreativesList(int accountId)
        {
            List<Creative> result = new List<Creative>();

            int limit = 5000;
            int offset = 0;
            DataContainer<Creative> container = GetAllCreatives(accountId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetAllCreatives(accountId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;
        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка креативов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="insertionId">Идентификатор объекта Sites/Offers</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Creative> GetCreatives(int accountId, int insertionId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/insertions/{insertionId}/creatives.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Creative>>(url);
        }

        /// <summary>
        /// Получение списка креативов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Creative> GetAllCreatives(int accountId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/creatives.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Creative>>(url);
        }

        #endregion
    }
}
