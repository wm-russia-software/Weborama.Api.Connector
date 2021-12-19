using System;
using System.Collections.Generic;
using System.Linq;
using Ak.Framework.Core.Extensions;
using Newtonsoft.Json.Linq;
using Weborama.Api.Connector.Enums;
using Weborama.Api.Connector.Models.Statistics;

namespace Weborama.Api.Connector.StatisticsResultsConverters
{
    /// <summary>
    /// Конвертер результатов статистического отчета по событиям
    /// </summary>
    internal class EventsStatisticsResultsConverter : BaseStatisticsResultsConverter
    {
        #region Публичные методы

        /// <summary>
        /// Преобразование json в список элементов статистического отчета
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="reportStartDate">Начальная дата отчета</param>
        /// <param name="reportEndDate">Конечная дата отчета</param>
        /// <returns></returns>
        public List<EventsStatisticsItem> Convert(string json, DateTime reportStartDate, DateTime reportEndDate)
        {
            List<EventsStatisticsItem> list = new List<EventsStatisticsItem>();

            JObject obj = JObject.Parse(json);

            List<Item> campaigns = GetMetadataItems(obj, Dimension.Campaign);
            List<Item> adSpaces = GetMetadataItems(obj, Dimension.Ad_Space);
            List<Item> insertions = GetMetadataItems(obj, Dimension.Insertion);
            List<Item> creatives = GetMetadataItems(obj, Dimension.Creative);
            List<Item> customEvents = GetMetadataItems(obj, Dimension.Custom_Event);

            JObject campaignsObject = obj["data"][Dimension.Campaign.ToStr().ToLower()]?.Value<JObject>();
            if (campaignsObject != null)
            {
                List<string> campaignIds = campaignsObject.Properties().Select(p => p.Name).ToList();
                foreach (string campaignId in campaignIds)
                {
                    Item campaign = campaigns.First(x => x.Id == campaignId.ToInt32());
                    JObject adSpacesObject = campaignsObject[campaignId][Dimension.Ad_Space.ToStr().ToLower()]?.Value<JObject>();
                    if (adSpacesObject != null)
                    {
                        List<string> adSpaceIds = adSpacesObject.Properties().Select(p => p.Name).ToList();
                        foreach (string adSpaceId in adSpaceIds)
                        {
                            Item adSpace = adSpaces.First(x => x.Id == adSpaceId.ToInt32());
                            JObject insertionsObject = adSpacesObject[adSpaceId][Dimension.Insertion.ToStr().ToLower()]?.Value<JObject>();
                            if (insertionsObject == null) 
                                continue;

                            List<string> insertionIds = insertionsObject.Properties().Select(p => p.Name).ToList();
                            foreach (string insertionId in insertionIds)
                            {
                                Item insertion = insertions.First(x => x.Id == insertionId.ToInt32());
                                JObject creativesObject = insertionsObject[insertionId][Dimension.Creative.ToStr().ToLower()]?.Value<JObject>();
                                if (creativesObject == null) 
                                    continue;

                                List<string> creativeIds = creativesObject.Properties().Select(p => p.Name).ToList();
                                foreach (string creativeId in creativeIds)
                                {
                                    Item creative = creatives.First(x => x.Id == creativeId.ToInt32());
                                    JObject customEventsObject = creativesObject[creativeId][Dimension.Custom_Event.ToStr().ToLower()]?.Value<JObject>();
                                    if (customEventsObject == null) 
                                        continue;


                                    Dictionary<string, decimal?> events = new Dictionary<string, decimal?>();
                                    List<string> customEventIds = customEventsObject.Properties().Select(p => p.Name).ToList();
                                    foreach (string customEventId in customEventIds)
                                    {
                                        JObject metrics = customEventsObject[customEventId]["metrics"]?.Value<JObject>();
                                        if (metrics == null) 
                                            continue;

                                        string eventValue = metrics["event"]?.Value<string>();
                                        events.Add(customEvents.First(x => x.Id == customEventId.ToInt32()).Name, eventValue.ToDecimal(null));
                                    }

                                    list.Add(new EventsStatisticsItem(reportStartDate, reportEndDate, campaign, adSpace, insertion, creative, events));
                                }
                            }
                        }
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
