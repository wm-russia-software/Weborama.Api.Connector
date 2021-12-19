using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с кампаниями
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Campaigns : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Campaigns(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Campaigns(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка кампаний
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <returns></returns>
        public List<Campaign> GetCampaignsList(int accountId, int? projectId = null)
        {
            List<Campaign> result = new List<Campaign>();

            int limit = 500;
            int offset = 0;
            DataContainer<Campaign> container = GetCampaigns(accountId, projectId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetCampaigns(accountId, projectId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;

        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка кампаний
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="projectId">Идентификатор проекта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Campaign> GetCampaigns(int accountId, int? projectId = null, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/campaigns.json?account_id={accountId}&list_offset={offset}");
            if (projectId.HasValue)
                url += $"&project_id={projectId.Value}";

            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Campaign>>(url);
        }

        #endregion
    }
}
