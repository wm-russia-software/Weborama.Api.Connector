using System;
using System.Collections.Generic;

namespace Weborama.Api.Connector.Models.Statistics
{
    /// <summary>
    /// Элемент статистического отчета по событиям
    /// </summary>
    public class EventsStatisticsItem : BaseStatisticsItem
    {
        #region Свойства

        /// <summary>
        /// События
        /// </summary>
        public Dictionary<string, decimal?> Events { get; }

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
        /// <param name="events">События</param>
        internal EventsStatisticsItem(DateTime startDate, DateTime endDate, Item campaign, Item adSpace, Item insertion, Item creative, Dictionary<string, decimal?> events) 
            : base(startDate, endDate, campaign, adSpace, insertion, creative)
        {
            Events = events;
        }

    #endregion
}
}
