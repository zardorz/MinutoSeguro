using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedAnalizerApp.Interfaces
{
    public interface IWord
    {
        Blog CountBlogFeeds(List<Feed> feeds, int topWords);
        List<Counter> WordsCountFromFeeds(List<Feed> feeds);
        List<Counter> WordsCountFromText(string text);
    }
}
