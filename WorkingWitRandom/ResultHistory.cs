using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithRandom
{
    public class ResultHistory<T>
    {
        private static List<List<T>> result = new List<List<T>>();

        public static void addElement(List<T> elem)
        {
            result.Add(elem);
        }
        public static List<T> removeElem(Type type)
        {
            var needRemove = result.Where(el => el.GetType() == type);

            int count = needRemove.ToList().Count();
            if (count == 0)
                return null;
            else
            {
                List<T> lastElem = needRemove.ToList()[needRemove.Count() - 1];

                int index = result.LastIndexOf(lastElem);
                result.RemoveAt(index);

                if (count == 1)
                    return new List<T>();
                else
                    return needRemove.ToList()[needRemove.Count() - 1];
            }
        }
    }
}
