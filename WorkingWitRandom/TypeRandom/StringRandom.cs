using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithRandom.TypeRandom
{
    public class StringRandom : IGenerator<string>
    {
        private HashSet<string> randomValues = new HashSet<string>();
        private Random rnd = new Random();
        private string getLetter()
        {
            return ((char)(rnd.Next(26) + 'a')).ToString();
        }
        public List<string> Generate()
        {
            randomValues.Clear();

            while (randomValues.Count != 3)
                randomValues.Add(getLetter() + getLetter() + getLetter());

            return randomValues.ToList();
        }
    }
}
