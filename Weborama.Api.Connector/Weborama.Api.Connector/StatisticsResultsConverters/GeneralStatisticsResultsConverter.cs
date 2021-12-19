using System;
using System.Collections.Generic;
using System.Linq;
using Ak.Framework.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Weborama.Api.Connector.Enums;
using Weborama.Api.Connector.Models.Statistics;
using MetricsContainer = Weborama.Api.Connector.Models.Statistics.Metrics;

namespace Weborama.Api.Connector.StatisticsResultsConverters
{
    /// <summary>
    /// Конвертер результатов общего статистического отчета
    /// </summary>
    internal class GeneralStatisticsResultsConverter : BaseStatisticsResultsConverter
    {
        #region Публичные методы

        /// <summary>
        /// Преобразование json в список элементов статистического отчета
        /// </summary>
        /// <param name="json">json</param>
        /// <param name="reportStartDate">Начальная дата отчета</param>
        /// <param name="reportEndDate">Конечная дата отчета</param>
        /// <returns></returns>
        public List<GeneralStatisticsItem> Convert(string json, DateTime reportStartDate, DateTime reportEndDate)
        {
            List<GeneralStatisticsItem> list = new List<GeneralStatisticsItem>();

            JObject obj = JObject.Parse(json);

            List<Item> campaigns = GetMetadataItems(obj, Dimension.Campaign);
            List<Item> adSpaces = GetMetadataItems(obj, Dimension.Ad_Space);
            List<Item> insertions = GetMetadataItems(obj, Dimension.Insertion);
            List<Item> creatives = GetMetadataItems(obj, Dimension.Creative);

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

                                    JObject metrics = creativesObject[creativeId]["metrics"]?.Value<JObject>();
                                    if (metrics == null)
                                        continue;

                                    MetricsContainer metricsContainer = JsonConvert.DeserializeObject<MetricsContainer>(metrics.ToStr());

                                    list.Add(new GeneralStatisticsItem(reportStartDate, reportEndDate, campaign, adSpace, insertion, creative, metricsContainer));
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
