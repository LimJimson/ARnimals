using System.Collections.Generic;

namespace HG.Collections
{
    public interface IReadOnlyList<T> : IReadOnlyCollection<T>,
        IEnumerable<T>
    {        
        T this[ int index ] { get; }
    }
}