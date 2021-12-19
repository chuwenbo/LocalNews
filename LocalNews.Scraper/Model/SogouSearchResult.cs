using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNews.Scraper.Model
{
    public class SogouSearchResult
    {
        public string URL { get; set; }
        public string SourceURL { get; set; }
        public string SourceName { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }

        public string NewsContentText { get; set; }
        public string NewsContentHtml { get; set; }
    }
}
