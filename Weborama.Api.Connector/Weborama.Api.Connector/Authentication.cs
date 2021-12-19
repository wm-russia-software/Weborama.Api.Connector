using System.Net;
using System.Net.Http;
using Ak.Framework.Core.Helpers;
using Newtonsoft.Json;
using RestSharp;
using Weborama.Api.Connector.Models;

namespace Weborama.Api.Connector
{
    /// <summary>
    /// Класс для работы с аутентификацией
    /// </summary>
    public class Authentication : BaseApiHandler
    {
        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        public Authentication()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="apiUrl">Url для доступа к Api</param>
        public Authentication(string apiUrl) : base(apiUrl)
        {
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Получение токена
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        public string GetToken(string login, string password)
        {
            string url = UrlHelper.CombineUrls(ApiUrl, @"/advertiser/advertiser_users/jwt_token/json");
            RestClient client = new RestClient(url) { Timeout = -1 };
            RestRequest request = new RestRequest(Method.POST);
            AddDefaultHeaders(request);
            request.AddParameter("email", login);
            request.AddParameter("password", password);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<Token>(response.Content).JwtToken;
            else
                throw new HttpRequestException($"Не удалось получить токен доступа к Weborama API. Код ответа: {response.StatusCode}");
        }

        #endregion
    }
}
