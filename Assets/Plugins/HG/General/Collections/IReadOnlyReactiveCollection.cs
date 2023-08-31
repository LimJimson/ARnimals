using System;

namespace HG.Collections
{
    public interface IReadOnlyReactiveCollection<T> : IReadOnlyCollection<T>
    {
        event Action<T> Removed;
        event Action<T> Added;
    }
}