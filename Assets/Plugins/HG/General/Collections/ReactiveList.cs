using System;
using System.Collections;
using System.Collections.Generic;
using HG.Extensions;
using UnityEngine;

namespace HG.Collections
{
    public class ReactiveList<T> : IReadOnlyCollection<T>, ICollection<T>, IReadOnlyReactiveCollection<T>
    {
        public event Action<T> Removed;
        public event Action<T> Added;
        
        private readonly List<T> _list;

        public ReactiveList(List<T> list)
        {
            Debug.Assert(list != null);
            _list = list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
            Added.InvokeSafe(item);
        }

        public void Clear()
        {
            List<T> toThrow = null;
            if(Removed != null)
                 toThrow = new List<T>(_list);
            
            _list.Clear();

            if (Removed != null)
            {
                foreach (var deleted in toThrow)
                {
                    Removed.Invoke(deleted);
                }
            }
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (_list.Remove(item))
            {
                Removed.InvokeSafe(item);
                return true;
            }

            return false;
        }

        public int Count
        {
            get { return _list.Count; }
        }
        
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        int IReadOnlyCollection<T>.Count
        {
            get { return Count; }
        }

        
    }
}