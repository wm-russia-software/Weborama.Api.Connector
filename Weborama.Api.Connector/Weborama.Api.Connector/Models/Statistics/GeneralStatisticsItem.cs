using System;

namespace Weborama.Api.Connector.Models.Statistics
{
    /// <summary>
    /// Элемент общего статистического отчета
    /// </summary>
    public class GeneralStatisticsItem : BaseStatisticsItem
    {
        #region Свойства

        /// <summary>
        /// Метрики
        /// </summary>
        public Metrics Metrics { get; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <param name="campaign">Кампания</param>
        /// <param name="adSpace">Рекламное пространство</param>
        /// <param name="insertion">Элемент Sites/Offers</param>
        /// <param name="creative">Креатив</param>
        /// <param name="metrics">Метрики</param>
        internal GeneralStatisticsItem(DateTime startDate, DateTime endDate, Item campaign, Item adSpace, Item insertion, Item creative, Metrics metrics) 
            : base(startDate, endDate, campaign, adSpace, insertion, creative)
        {
            Metrics = metrics;
        }

        #endregion
    }
}
