using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNews.Service.Entity
{
    public class LocalNews_Content
    {
        public Guid ID { get; set; }
        public Guid LocalNews_Main_ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
