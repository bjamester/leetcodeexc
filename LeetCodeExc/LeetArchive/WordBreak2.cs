using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class WordBreak2 : IRunnable
    {
        public void Run()
        {
            RunWith("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" });
        }

        private void RunWith(string s, IList<string> words)
        {
            var result = WordBreak(s, words);
            Logger.LogLine($"Input string: {s}");
            Logger.LogLine($"Input words: [{string.Join(',', words)}]");
            Logger.LogLine($"Results:");

            foreach (var sentence in result)
                Logger.LogLine($"   {sentence}");
        }

        public IList<string> WordBreak(string s, IList<string> words)
        {
            var wordCounts = words.ToDictionary(w => w, w => s.IndexOf(w, StringComparison.OrdinalIgnoreCase));
            var result = new List<string>();
            AddNextHit(s, wordCounts, 0, new List<string>(), result);
            return result;
        }

        private bool AddNextHit(string zipped, IDictionary<string, int> wordCounts, int currentIndex, IList<string> hits, IList<string> result)
        {
            
            var found = false;

            while (currentIndex < zipped.Length)
            {
                var currentWords = wordCounts.Where(w => w.Value == currentIndex);
                var countIndex = currentWords.Count();
                foreach(var word in currentWords)
                {

                    if (currentIndex > zipped.Length)
                        return false;

                    if (--countIndex > 0)
                    {
                        currentIndex += word.Key.Length;
                        var newHits = hits.ToList();
                        newHits.Add(word.Key);
                        found = AddNextHit(zipped, wordCounts, currentIndex, newHits, result);
                    }
                    else
                    {
                        currentIndex += word.Key.Length;
                        hits.Add(word.Key);
                    }

                    //if (found)
                    //    break;
                }

                //if (found)
                //    break;
            }

            if (currentIndex == zipped.Length)
            {
                result.Add(string.Join(' ', hits));
                return true;
            }

            return found;
        }
    }
}
