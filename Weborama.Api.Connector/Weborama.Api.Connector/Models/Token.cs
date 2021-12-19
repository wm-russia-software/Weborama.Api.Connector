using Newtonsoft.Json;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Токен
    /// </summary>
    internal class Token
    {
        #region Свойства

        /// <summary>
        /// JWT токен
        /// </summary>
        [JsonProperty("jwt_token")]
        public string JwtToken { get; set; }

        #endregion
    }
}
