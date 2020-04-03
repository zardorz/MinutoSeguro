using System;
using System.Collections.Generic;
using System.Text;

namespace FeedAnalizerApp.Models
{
    public class Blog
    {
        public List<Counter> TopTenWords { get; set; }
        public List<Feed> Feeds { get; set; }
        public List<FeedCount> FeedsCount { get; set; }
    }
}
