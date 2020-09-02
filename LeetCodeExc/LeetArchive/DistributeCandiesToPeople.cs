using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeExc
{
    public class DistributeCandiesToPeople : IRunnable
    {
        public void Run()
        {
            RunWith(7, 4);
            RunWith(10, 3);
        }

        private void RunWith(int candies, int people)
        {
            var result = DistributeCandies(candies, people);
            Logger.LogLine($"Candies: {candies}; People: {people}");
            Logger.LogLine($"Result: [{string.Join(',', result)}]");
        }

        public int[] DistributeCandies(int candies, int num_people)
        {
            var people = new int[num_people];
            var portion = 0;
            while(candies > 0)
            {
                for(int i = 0; i < num_people && candies > 0; i++)
                {
                    portion = Math.Min(candies, portion + 1);
                    candies -= portion;
                    people[i] += portion;
                }
            }

            return people;
        }
    }
}
