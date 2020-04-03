using FeedAnalizerApp.Interfaces;
using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedAnalizerApp.Services
{
    public class PrinterService : IPrinter
    {
        public void PrintBlogDetails(Blog blog)
        {

            Console.WriteLine("Top Ten Words");
            foreach (var item in blog.TopTenWords)
            {
                Console.WriteLine($"\tWord: {item.Word}, Count: {item.Count}");
            }

            Console.WriteLine("\r\n");

            Console.WriteLine("Feed Word Counts");
            foreach (var item in blog.FeedsCount)
            {
                Console.WriteLine($"\tWord: {item.Feed.Url}, Count: {item.WordCount}");
            }

        }
    }
}
