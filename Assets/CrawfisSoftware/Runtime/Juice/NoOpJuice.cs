using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "NoJuice", menuName = "CrawfisSoftware/Juice/No-op")]
    public class NoOpJuice : JuiceAbstract
    {
        public override IEnumerator Play(MonoBehaviour _)
        {
            yield break;
        }
    }
}