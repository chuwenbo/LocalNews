using HtmlAgilityPack;
using LocalNews.Scraper.ContentScraper;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LocalNews.Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //FuncTest();

            SogouHelper sogouHelper = new SogouHelper("潍坊");
            var sogouResult = sogouHelper.GetSearchResult();

            Console.ReadLine();
        } 

        /// <summary>
        /// https://developers.weixin.qq.com/doc/offiaccount/Basic_Information/Get_access_token.html
        /// </summary>
        /// <returns></returns>
        static async Task GetAccessToken()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wx38530330499d1aa5&secret=1e287791c061324d3410390429ad2d8b");
                Console.WriteLine(content);

                //{"access_token":"51_ZCNZB8knsWdXgT5upbdKoU6mDVWiz23JM52wKR_UMWgtkGJor6qQ9RBi81KnMBJM57bpigXGnoYuZ3PKNRHJO7T4ie0nxxFldjR18mB1l_zIJmgz3xOhgCc4EHvGnAzGNLdr1YeNDPVcS0WBZQHiAIADUL","expires_in":7200}
            }
        }

        /// <summary>
        /// https://developers.weixin.qq.com/doc/offiaccount/Draft_Box/Add_draft.html
        /// </summary>
        /// <returns></returns>
        static async Task<object> AddDraft()
        {
            try
            {
                //using (HttpClient client = new HttpClient())
                //{
                //    var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                //    var response = await client.PostAsync(url, content);
                //    if (response != null)
                //    {
                //        var jsonString = await response.Content.ReadAsStringAsync();
                //        return JsonConvert.DeserializeObject<object>(jsonString);
                //    }
                //}
            }
            catch (Exception ex)
            {
                //myCustomLogger.LogException(ex);
            }
            return null;
        }

        static void FuncTest()
        {
            NetEase163Scraper netEase163Scraper = new NetEase163Scraper();
            var netEase163Content = netEase163Scraper.GetContent("https://www.163.com/dy/article/GRHNVIMS0550BVN1.html?f=post2020_dy_recommends");
            Console.WriteLine(netEase163Content.Title);
            Console.WriteLine(netEase163Content.ContentText);
            Console.WriteLine(netEase163Content.ContentHtml);

            return;

            TencentScraper tencentScraper = new TencentScraper();
            var tencentContent = tencentScraper.GetContent("https://new.qq.com/rain/a/20211219A01D9X00");
            Console.WriteLine(tencentContent.Title);
            Console.WriteLine(tencentContent.ContentText);
            Console.WriteLine(tencentContent.ContentHtml); 
            

            SohuScraper sohuScraper = new SohuScraper();
            var sohuContent = sohuScraper.GetContent("https://www.sohu.com/a/509604411_556233");
            Console.WriteLine(sohuContent.Title);
            Console.WriteLine(sohuContent.ContentText);
            Console.WriteLine(sohuContent.ContentHtml);
        }
    }
}
