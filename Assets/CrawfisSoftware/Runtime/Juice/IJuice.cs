using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    public interface IJuice
    {
        IEnumerator Play(MonoBehaviour context);
    }
}