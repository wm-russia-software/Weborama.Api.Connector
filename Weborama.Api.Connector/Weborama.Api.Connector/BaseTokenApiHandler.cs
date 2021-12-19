using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Ak.Framework.Core.Extensions;
using Newtonsoft.Json;
using RestSharp;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Базовый обработчик API
    /// </summary>
    public abstract class BaseTokenApiHandler : BaseApiHandler
    {
        #region Свойства

        /// <summary>
        /// Идентификатор аккаунта
        /// </summary>
        public int AccountId { get; }

        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="token">Токен</param>
        protected BaseTokenApiHandler(int accountId, string token)
        {
            AccountId = accountId;
            Token = token;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        /// <param name="accountId">Идентификатор аккаунта</param>
        /// <param name="token">Токен</param>
        protected BaseTokenApiHandler(string apiUrl, int accountId, string token) : base(apiUrl)
        {
            AccountId = accountId;
            Token = token;
        }

        #endregion

        #region Защищенные методы

        /// <summary>
        /// Добавление заголовков запроса по умолчанию
        /// </summary>
        /// <param name="request">Запрос</param>
        protected override void AddDefaultHeaders(RestRequest request)
        {
            request.AddHeader("X-Weborama-JWTUserAuthToken", Token);
            request.AddHeader("X-Weborama-Account_Id", AccountId.ToStr());
        }

        /// <summary>
        /// Получение данных из API
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="url">Url</param>
        /// <param name="verb">Метода получения данных</param>
        /// <returns></returns>
        protected T GetDataFromApi<T>(string url, Method verb = Method.GET)
        {
            RestClient client = new RestClient(url) { Timeout = -1 };
            RestRequest request = new RestRequest(verb);
            AddDefaultHeaders(request);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<T>(response.Content);
            else
                throw new HttpRequestException($"Не удалось получить данные при обращении к Weborama API с помощью метода {verb}. Url: {url}. Код ответа: {response.StatusCode}. Content: {response.Content}");
        }

        /// <summary>
        /// Получение данных из API
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="verb">Метода получения данных</param>
        /// <returns></returns>
        protected string GetDataFromApi(string url, Method verb = Method.GET)
        {
            RestClient client = new RestClient(url) { Timeout = -1 };
            RestRequest request = new RestRequest(verb);
            AddDefaultHeaders(request);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return response.Content;
            else
                throw new HttpRequestException($"Не удалось получить данные при обращении к Weborama API с помощью метода {verb}. Url: {url}. Код ответа: {response.StatusCode}. Content: {response.Content}");
        }

        /// <summary>
        /// Получение строкового представления массива 
        /// </summary>
        /// <param name="items">Элементы</param>
        /// <returns></returns>
        protected string GetStringFormatOfArray(IEnumerable<Enum> items)
        {
            return GetStringFormatOfArray(items.SelectEx(x => x.ToStr().ToLower()));
        }

        /// <summary>
        /// Получение строкового представления массива
        /// </summary>
        /// <param name="items">Элементы</param>
        /// <returns></returns>
        protected string GetStringFormatOfArray(IEnumerable<string> items)
        {
            return string.Join(",", items.SelectEx(x => $"\"{x}\""));
        }

        #endregion
    }
}
