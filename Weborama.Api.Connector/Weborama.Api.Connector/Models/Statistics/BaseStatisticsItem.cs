using System;

namespace Weborama.Api.Connector.Models.Statistics
{
    /// <summary>
    /// Базовый класс для элемента статистического отчета
    /// </summary>
    public abstract class BaseStatisticsItem
    {
        #region Свойства

        /// <summary>
        /// Начальная дата
        /// </summary>
        public DateTime StartDate { get; }

        /// <summary>
        /// Конечная дата
        /// </summary>
        public DateTime EndDate { get; }

        /// <summary>
        /// Кампания
        /// </summary>
        public Item Campaign { get; }

        /// <summary>
        /// Рекламное пространство
        /// </summary>
        public Item AdSpace { get; }

        /// <summary>
        /// Элемент Sites/Offers
        /// </summary>
        public Item Insertion { get; }

        /// <summary>
        /// Креатив
        /// </summary>
        public Item Creative { get; }

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
        internal BaseStatisticsItem(DateTime startDate, DateTime endDate, Item campaign, Item adSpace, Item insertion, Item creative)
        {
            StartDate = startDate;
            EndDate = endDate;
            Campaign = campaign;
            AdSpace = adSpace;
            Insertion = insertion;
            Creative = creative;
        }

        #endregion
    }
}
