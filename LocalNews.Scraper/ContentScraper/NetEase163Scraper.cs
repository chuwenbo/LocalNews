using HtmlAgilityPack;
using LocalNews.Scraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalNews.Scraper.ContentScraper
{
    public class NetEase163Scraper: IContentScraperFactory
    {
        public NewsContentModel GetContent(string url)
        {
            var res = new NewsContentModel();

            var maxAttemptCount = 3;
            var retryInterval = TimeSpan.FromSeconds(5);

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                if (attempted > 0)
                {
                    Console.WriteLine(string.Format("Get tencent content {0} retry.", attempted));
                    Thread.Sleep(retryInterval);
                }

                try
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(url);

                    var titleNode = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'post_title')]");

                    var articleNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'post_body')]");

                    res.Title = titleNode.InnerText;
                    res.ContentText = articleNode.InnerText;
                    res.ContentHtml = articleNode.InnerHtml;

                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return res;
        }
    }
}
