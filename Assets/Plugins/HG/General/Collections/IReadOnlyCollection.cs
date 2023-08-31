using System.Collections.Generic;

namespace HG.Collections
{
    public interface IReadOnlyCollection<T> : IEnumerable<T>
    {
        int Count { get; }
    }
}