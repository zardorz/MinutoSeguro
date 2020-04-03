using FeedAnalizerApp.Interfaces;
using FeedAnalizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeedAnalizerApp.Services
{
    public class WordService : IWord
    {
        private static readonly IEnumerable<string> BlackWordsList = new List<string>()
        {
             "e" ,"é", "a", "o", "as", "os", "para", "pra", "pro", "na", "nas", "no", "nos", "de", "do", "da", "das", "dos", "em", "por", "à", "de", "do", "dos", "da", "das", "os", "as", "um", "uns", "uma", "umas", "dum", "duma", "dum", "dumas", "em", "no", "nos", "na", "nas", "num", "nuns", "numa", "numas", "por", "pelo", "pelos", "pela", "pela", "com", "ao", "aos", "ante", "até", "após", "contra", "desde", "entre", "para", "por", "perante", "sem", "sob", "sobre", "daqui", "nele", "nela", "pela", "nesse", "nessa", "naquele", "naquela", "neste", "nesta", "que", "qual", "não",
        };

        public Blog CountBlogFeeds(List<Feed> feeds, int topWords)
        {
            var wordsCount = WordsCountFromFeeds(feeds);

            //principais palavras abordadas nos tópicos pela numero de exibições
            var topTenWords = wordsCount.OrderByDescending(x => x.Count).Take(topWords).ToList();

            //Também deverá exibir a quantidade de palavras por tópico
            var feedsCount = (from f in feeds
                              select new FeedCount()
                              {
                                  Feed = f,
                                  WordCount = WordsCountFromText(f.Sumario).Select(ws => ws.Count).Sum()
                              }).ToList();


            var blog = new Blog()
            {
                TopTenWords = topTenWords,
                Feeds = feeds,
                FeedsCount = feedsCount
            };


            return blog;
        }

        public List<Counter> WordsCountFromFeeds(List<Feed> feeds)
        {
            //concatena os itens dos sumarios e gera as palavras
            var words = String.Join(" ", feeds.Select(m => m.Sumario).ToArray());

            //conta o número de vezes que as palavras aparecem
            var wordsCount = WordsCountFromText(words);

            return wordsCount;

        }

        public List<Counter> WordsCountFromText(string text)
        {
            // remove as palavras proibidas
            var wordsSplit = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => !BlackWordsList.Contains(w));

            //conta o número de vezes que as palavras aparecem
            var wordsCount = wordsSplit.GroupBy(r => r).Select(grp => new Counter()
            {
                Word = grp.Key,
                Count = grp.Count()
            }).ToList();

            return wordsCount;

        }

    }
}
