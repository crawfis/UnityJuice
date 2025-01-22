using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.WaitEnumerable
{
    public class WaitForKeyPressEnumerable : MonoBehaviour, IEnumerable
    {
        public KeyCode Key { get; set; }
        private bool _predicate;
        public IEnumerator GetEnumerator()
        {
            _predicate = false;
            yield return new WaitUntil(() => { return _predicate; });
        }

        [ExecuteAlways]
        void Update()
        {
            if (Input.GetKeyDown(Key))
            {
                _predicate = true;
            }
        }
    }
}