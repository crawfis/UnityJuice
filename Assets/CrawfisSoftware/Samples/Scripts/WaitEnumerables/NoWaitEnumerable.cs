using System.Collections;

namespace CrawfisSoftware.WaitEnumerable
{
    public class NoWaitEnumerable : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield break;
        }
    }
}