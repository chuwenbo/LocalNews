using HtmlAgilityPack;
using LocalNews.Scraper.ContentScraper;
using LocalNews.Scraper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalNews.Scraper
{
    public class SogouHelper
    {
        private string _keyword;
        private string _searchURL = "https://www.sogou.com/sogou?interation=1728053249&interV=&pid=sogou-wsse-8f646834ef1adefa&query={0}&page=1&ie=utf8&p=40230447&dp=1";

        public SogouHelper(string keyword)
        {
            this._keyword = keyword;
            this._searchURL = String.Format(this._searchURL, keyword);
        }

        /// <summary>
        /// Get news content on first page.
        /// </summary>
        /// <returns></returns>
        public List<SogouSearchResult> GetSearchResult()
        {
            var res = new List<SogouSearchResult>();

            var maxAttemptCount = 3;
            var retryInterval = TimeSpan.FromSeconds(5);

            for(int attempted =0; attempted < maxAttemptCount; attempted++)
            {
                if (attempted > 0)
                {
                    Console.WriteLine(string.Format("GetSogouSearchResult {0} retry.", attempted));
                    Thread.Sleep(retryInterval);
                }

                try
                {
                    var web = new HtmlWeb();
                    var doc = web.Load(this._searchURL);

                    var articleNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'vrwrap')]");

                    foreach (var node in articleNodes)
                    {
                        var singleResult = new SogouSearchResult();

                        var link = node.SelectSingleNode(".//a[@href]");
                        string hrefValue = link.GetAttributeValue("href", string.Empty);
                        Console.WriteLine(hrefValue);
                        Console.WriteLine(link.InnerText);

                        singleResult.URL = hrefValue;
                        singleResult.Title = link.InnerText;
                        singleResult.SourceURL = this.GetRedirectedUrl(singleResult.URL);

                        if (string.IsNullOrEmpty(singleResult.SourceURL)) continue;

                        var newsFrom = node.SelectSingleNode(".//p[contains(@class, 'news-from')]");
                        string newsSrc = newsFrom.ChildNodes[1].InnerText;
                        string newsDate = this.ConvertToDate(newsFrom.ChildNodes[2].InnerText);
                        Console.WriteLine(newsSrc);
                        Console.WriteLine(newsDate);

                        singleResult.SourceName = newsSrc.Trim();
                        singleResult.ReleaseDate = newsDate;

                        //Get the news content
                        var scraper = ContentScraperFactory.CreateScraper(singleResult.SourceName);
                        if (scraper == null) continue;

                        
                        var newsContent = scraper.GetContent(singleResult.SourceURL);
                        singleResult.NewsContentText = newsContent.ContentText;
                        singleResult.NewsContentHtml = newsContent.ContentHtml;

                        res.Add(singleResult);
                    }

                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateDiff">//17分钟前  1小时前</param>
        /// <returns></returns>
        public string ConvertToDate(string dateDiff)
        {
            string res = string.Empty;

            if (string.IsNullOrEmpty(dateDiff)) return res;
            res = res.Trim();

            if (dateDiff.Contains("分钟前"))
            {
                dateDiff = dateDiff.Replace("分钟前", "");

                res = DateTime.Now.AddMinutes(-Int32.Parse(dateDiff)).ToString();
            }

            if (dateDiff.Contains("小时前"))
            {
                dateDiff = dateDiff.Replace("小时前", "");
                res = DateTime.Now.AddHours(-Int32.Parse(dateDiff)).ToString();
            }

            return res;
        }

        public string GetRedirectedUrl(string url)
        {
            string redirectedUrl = string.Empty;

            var maxAttemptCount = 3;
            var retryInterval = TimeSpan.FromSeconds(5);

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                if (attempted > 0)
                {
                    Console.WriteLine(string.Format("GetRedirectedUrl {0} retry.", attempted));
                    Thread.Sleep(retryInterval);
                }

                try
                {
                    //get redirect URL
                    //"https://www.sogou.com/link?url=6IqLFeTuIyhfYJ1Ai-ptaljpXp0hu3m0_B1659cXznVPPFT_7r3hy2WpLqI5bpMQmiuLiGqDoait5pUc3zy0dg..";
                    url = "https://www.sogou.com" + url;
                    var web = new HtmlWeb();
                    web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36";
                    web.CaptureRedirect = true;
                    var doc = web.LoadFromWebAsync(url).Result;
                    string txt = doc.DocumentNode.InnerHtml;

                    int i1 = txt.IndexOf("(\"");
                    int i2 = txt.IndexOf("\")");

                    redirectedUrl = txt.Substring(i1 + 2, i2 - i1 - 2);

                    return redirectedUrl;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 

            return redirectedUrl;
        }
    }
}
