using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNews.Scraper.Model
{
    public class NewsContentModel
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
        public string ContentHtml { get; set; }
    }
}
