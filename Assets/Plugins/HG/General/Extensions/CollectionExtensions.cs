using System;
using System.Collections;
using System.Collections.Generic;

namespace HG.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (!seenKeys.Contains(keySelector(element)))
                {
                    seenKeys.Add(keySelector(element));
                    yield return element;
                }
            }
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }
        
        public static void ForEach<T>(this IList<T> list, Action<T> action) 
        {
            if (list == null) throw new ArgumentNullException("null");
            if (action == null) throw new ArgumentNullException("action");

            for (int i = 0; i < list.Count; i++)
            {
                action(list[i]);
            }
        }
    }
}