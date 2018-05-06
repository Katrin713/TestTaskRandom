using System.Collections.Generic;

namespace WorkingWithRandom.TypeRandom
{
    public interface IGenerator<T>
    {
        List<T> Generate();
    }
}
