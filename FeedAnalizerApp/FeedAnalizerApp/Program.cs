using FeedAnalizerApp.Interfaces;
using FeedAnalizerApp.Models;
using FeedAnalizerApp.Services;
using System;


namespace FeedAnalizerApp
{
    class Program
    {
        static IDowloadFeed dowloadFeed;
        static IWord word;
        static IPrinter printer;


        static void Main(string[] args)
        {
            dowloadFeed = new DowloadFeedService();
            var feeds = dowloadFeed.GetFeeds("http://www.minutoseguros.com.br/blog/feed/");

            word = new WordService();
            var blogDetails = word.CountBlogFeeds(feeds, 10);

            printer = new PrinterService();
            printer.PrintBlogDetails(blogDetails);

            Console.ReadLine();
        }

    }

}