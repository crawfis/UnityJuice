using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.WaitEnumerable
{
    public class WaitForSecondsEnumerable : IEnumerable
    {
        private float _seconds;
        public WaitForSecondsEnumerable(float seconds)
        {
            _seconds = seconds;
        }
        public IEnumerator GetEnumerator()
        {
            yield return new WaitForSeconds(_seconds);
        }
    }
}