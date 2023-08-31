using System;

namespace HG
{
    public interface ICollectionManipulator : IDisposable
    {
        event Action OnRefreshRequired;
    }
}