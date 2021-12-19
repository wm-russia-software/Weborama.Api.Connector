using System;
using Newtonsoft.Json;

namespace Weborama.Api.Connector.Models
{
    /// <summary>
    /// Рекламная сеть
    /// </summary>
    public class AdNetwork
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        [JsonProperty("label")]
        public string Name { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        [JsonProperty("status")]
        public string State { get; set; }

        /// <summary>
        /// Тип рекламной сети
        /// </summary>
        [JsonProperty("ad_network_type")]
        public string AdNetworkType { get; set; }

        /// <summary>
        /// Платформа
        /// </summary>
        [JsonProperty("third_party_platform")]
        public string ThirdPartyPlatform { get; set; }
        
        /// <summary>
        /// Идентификатор страны
        /// </summary>
        [JsonProperty("country_id")]
        public int CountryId { get; set; }
        
        /// <summary>
        /// Дата создания
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Дата удаления
        /// </summary>
        [JsonProperty("deleted_at")]
        public DateTime? Deleted { get; set; }
    }
}
