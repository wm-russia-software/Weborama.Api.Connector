using RestSharp;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Базовый обработчик API
    /// </summary>
    public abstract class BaseApiHandler
    {
        #region Переменные и константы

        /// <summary>
        /// Url для доступа к Api
        /// </summary>
        private const string CommonApiUrl = "https://api-wcm.weborama.com";

        #endregion

        #region Свойства

        /// <summary>
        /// Url для доступа к Api
        /// </summary>
        public string ApiUrl { get; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        protected BaseApiHandler()
        {
            ApiUrl = CommonApiUrl;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        protected BaseApiHandler(string apiUrl)
        {
            ApiUrl = apiUrl;
        }

        #endregion

        #region Защищенные методы

        /// <summary>
        /// Добавление заголовков запроса по умолчанию
        /// </summary>
        /// <param name="request">Запроса</param>
        protected virtual void AddDefaultHeaders(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        }

        #endregion
    }
}
