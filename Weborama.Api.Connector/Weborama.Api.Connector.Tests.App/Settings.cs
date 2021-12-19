using System.Configuration;
using Ak.Framework.Core.Extensions;

namespace Weborama.Api.Connector.Tests.App
{
    /// <summary>
    /// Настройки
    /// </summary>
    internal class Settings
    {
        #region Свойства

        /// <summary>
        /// Логин для доступа к Weborama API
        /// </summary>
        public static string WeboramaLogin => ConfigurationManager.AppSettings["WeboramaLogin"].ToStr();

        /// <summary>
        /// Пароль для доступа к Weborama API
        /// </summary>
        public static string WeboramaPassword => ConfigurationManager.AppSettings["WeboramaPassword"].ToStr();

        /// <summary>
        /// Идентификатор аккаунта Weborama
        /// </summary>
        public static int WeboramaAccountId => ConfigurationManager.AppSettings["WeboramaAccountId"].ToInt32();

        #endregion
    }
}
