using System;
using System.Collections;
using System.Collections.Generic;
using HG.Extensions;
using UnityEngine;

namespace HG
{
    // @LATER implement IEnumerator similar to Dictionary (look up its impl)
    public class SerializableDictionary<TKey, TValue> : IDisposable where TKey: IComparable
    {
        // Throws an event whith key of which values was changed
        public event Action<TKey> OnValueChanged;
        public event Action OnDictionaryChanged;
        
        [SerializeField] private List<TKey> _keys = new List<TKey>();
        [SerializeField] private List<TValue> _values = new List<TValue>();
        
        public IEnumerable<TKey> Keys
        {
            get { return _keys; }
        }
        
        public IEnumerable<TValue> Values
        {
            get { return _values; }
        }
        
        public virtual void Set(TKey key, TValue value)
        {
            var keyIndex = GetKeyIndex(key);
            if (keyIndex == -1)
            {
                _keys.Add(key);
                _values.Add(value);
            }
            else
            {
                _values[keyIndex] = value;
            }

            OnValueChanged.InvokeSafe(key);
            OnDictionaryChanged.InvokeSafe();
        }

        public virtual TValue Get(TKey key, TValue defaultValue = default(TValue))
        {
            var keyIndex = GetKeyIndex(key);
            if (keyIndex == -1)
            {
                return defaultValue;
            }
            else
            {
                return _values[keyIndex];
            }
        }

        public void Remove(TKey key)
        {
            var keyIndex = GetKeyIndex(key);
            if (keyIndex != -1)
            {
                _keys.RemoveAt(keyIndex);
                _values.RemoveAt(keyIndex);
                
                OnValueChanged.InvokeSafe(key);
                OnDictionaryChanged.InvokeSafe();
            }
        }
        
        // return -1 if not found
        private int GetKeyIndex(TKey key)
        {
            for (int i = 0; i < _keys.Count; ++i)
            {
                if (Equals(_keys[i], key))
                {
                    return i;
                }
            }
            return -1;
        }

        // Note: Calls OnValueChanged for each value so that persistency & ui can be updated correctly
        public void Clear()
        {
            var keysTmp = new List<TKey>(_keys); // Note: copy keys to avoid modification from subscribers
            
            _keys.Clear();
            _values.Clear();

            foreach (var key in keysTmp)
            {
                OnValueChanged.InvokeSafe(key);
            }
            
            OnDictionaryChanged.InvokeSafe();
        }

        public void Dispose()
        {
            OnValueChanged = null;
            OnDictionaryChanged = null;
        }
    }
}