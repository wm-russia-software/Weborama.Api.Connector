using System.Collections.Generic;
using Ak.Framework.Core.Helpers;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с проектами
    /// </summary>
    /// <seealso cref="Weborama.Api.Connector.BaseTokenApiHandler" />
    public class Projects : BaseTokenApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Projects(int clientId, string token) : base(clientId, token)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="token">Токен</param>
        public Projects(string apiUrl, int clientId, string token) : base(apiUrl, clientId, token)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение списка проектов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <returns></returns>
        public List<Project> GetProjectsList(int accountId)
        {
            List<Project> result = new List<Project>();

            int limit = 100;
            int offset = 0;
            DataContainer<Project> container = GetProjects(accountId, limit);
            if (container.Values != null)
            {
                offset = container.ItemsPerPage;
                result.AddRange(container.Values);
            }

            while (offset < container.Total)
            {
                container = GetProjects(accountId, limit, offset);
                result.AddRange(container.Values);
                offset += container.ItemsPerPage;
            }

            return result;

        }

        #endregion

        #region Приватные методы

        /// <summary>
        /// Получение списка проектов
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="limit">Максимальное количество возвращаемых записей</param>
        /// <param name="offset">Сдвиг на заданное количество записей</param>
        /// <returns></returns>
        private DataContainer<Project> GetProjects(int accountId, int? limit = null, int offset = 0)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, $@"advertiser/projects.json?account_id={accountId}&list_offset={offset}");
            if (limit.HasValue)
                url += $"&list_limit={limit.Value}";

            return GetDataFromApi<DataContainer<Project>>(url);
        }

        #endregion
    }
}
