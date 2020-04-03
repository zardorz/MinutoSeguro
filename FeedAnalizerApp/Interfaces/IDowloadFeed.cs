using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedAnalizerApp.Interfaces
{
    public interface IDowloadFeed
    {
        List<Feed> GetFeeds(string uri);
    }
}
