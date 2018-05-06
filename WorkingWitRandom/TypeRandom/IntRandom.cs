using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithRandom.TypeRandom
{
    public class IntRandom : IGenerator<int>
    {
        private HashSet<int> randomValues = new HashSet<int>();

        public List<int> Generate()
        {
            randomValues.Clear();
            Random rnd = new Random();

            while (randomValues.Count != 3)
                randomValues.Add(rnd.Next(256));

            return randomValues.ToList();
        }
    }
}
