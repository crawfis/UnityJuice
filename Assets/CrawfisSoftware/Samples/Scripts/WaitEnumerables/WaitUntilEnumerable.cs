using System;
using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.WaitEnumerable
{
    public class WaitUntilEnumerable : IEnumerable
    {
        private Func<bool> _predicate;
        public WaitUntilEnumerable(Func<bool> predicate)
        {
            _predicate = predicate;
        }
        public IEnumerator GetEnumerator()
        {
            yield return new WaitUntil(_predicate);
        }
    }
}