using FeedAnalizerApp.Interfaces;
using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;

using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FeedAnalizerApp.Services
{
    public class DowloadFeedService : IDowloadFeed
    {
        public List<Feed> GetFeeds(string uri)
        {
            var feeds = new List<Feed>();

            using (var reader = XmlReader.Create("http://www.minutoseguros.com.br/blog/feed/"))
            {
                var feedBlog = SyndicationFeed.Load(reader);

                //Sumario = Regex.Replace(f.Summary.Text, "[&#8230;][']", ""), //WebUtility.HtmlDecode(
                feeds = (from f in feedBlog.Items
                             select new Feed()
                             {

                                 Titulo = f.Title.Text,
                                 Sumario = f.Summary.Text.CleanString(),
                                 Url = f.Id
                             }).ToList();
                
            }

            return feeds;
        }
    }
}
