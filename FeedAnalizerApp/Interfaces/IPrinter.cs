using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedAnalizerApp.Interfaces
{
    public interface IPrinter
    {
        void PrintBlogDetails(Blog blog);
    }
}
