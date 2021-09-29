using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNews.Service.Entity
{
    public class LocalNews_Main
    {
        public Guid ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }

        public string URL { get; set; }
        public int DataSource { get; set; }
    }
}
