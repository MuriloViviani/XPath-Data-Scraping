using HtmlAgilityPack;
using System;

namespace XPath
{
    class ScrappingData
    {
        /// <summary>
        /// Simple example of data scraping using the HTMLAgilityPack NuGet
        /// </summary>
        /// <param name="args">No use here</param>
        static void Main(string[] args)
        {
            // List of XPaths References, the data is going to be scrapped from here
            var xPaths = new string[]
                {
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[1]/span[2]", // CPTM's Line 7 Situation XPath
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[2]/span[2]", // CPTM's Line 8 Situation XPath
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[3]/span[2]", // CPTM's Line 9 Situation XPath
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[4]/span[2]", // CPTM's Line 10 Situation XPath
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[3]/span[2]", // CPTM's Line 11 Situation XPath
                    "//*[@id=\"destaques\"]/div[2]/div[2]/div/div[3]/span[2]" // CPTM's Line 12 Situation XPath
                };

            Console.WriteLine("Loading data Source (this might take a while)...");

            // The source of the data
            var Url = "http://www.cptm.sp.gov.br/Pages/Home.aspx";
            HtmlWeb web = new HtmlWeb();
            // Loads the data source
            HtmlDocument doc = web.Load(Url);

            Console.WriteLine("\nLines Situations");
            Console.WriteLine("=========================");

            int count = 7;
            foreach (var key in xPaths)
            {
                // Get the data in the source, using the XPath as base
                var response = doc.DocumentNode.SelectNodes(key)[0].InnerText.Replace('\n', ' ').Replace('\t', ' ').Trim();
                Console.WriteLine("Line " + count + " Situation");
                Console.Write("\t" + response + "\n");
                count++;
            }

            Console.WriteLine("=========================\n");
            Console.WriteLine("Press \"Enter\" to exit...");
            Console.Read();
        }
    }
}
