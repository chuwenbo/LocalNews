using LocalNews.Scraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNews.Scraper.ContentScraper
{
    public interface IContentScraperFactory
    {
        public NewsContentModel GetContent(string url);
    }

    public class ContentScraperFactory
    {
        //网易 腾讯网 搜狐 网易订阅
        //凤凰网
        public static IContentScraperFactory CreateScraper(string srcName)
        {
            IContentScraperFactory fact = null;

            switch (srcName)
            {
                case "搜狐":
                    fact = new SohuScraper();
                    break;
                case "网易":
                    fact = new NetEase163Scraper();
                    break;
                case "网易订阅":
                    fact = new NetEase163Scraper();
                    break;
                case "腾讯网":
                    fact = new TencentScraper();
                    break;

                default: break;
            }

            return fact;
        }
    }
}
