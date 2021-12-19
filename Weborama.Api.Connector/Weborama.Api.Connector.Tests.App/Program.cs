using System;
using Ak.Framework.Core.Extensions;

namespace Weborama.Api.Connector.Tests.App
{
    /// <summary>
    /// Программа
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Аргументы</param>
        static void Main(string[] args)
        {
            string token = new Authentication().GetToken(Settings.WeboramaLogin, Settings.WeboramaPassword);
            var adSpaces = new AdSpaces(Settings.WeboramaAccountId, token).GetAdSpacesList(Settings.WeboramaAccountId);
            var insertions = new Insertions(Settings.WeboramaAccountId, token).GetInsertionsList(Settings.WeboramaAccountId);
            var creatives = new Creatives(Settings.WeboramaAccountId, token).GetCreativesList(Settings.WeboramaAccountId);

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
