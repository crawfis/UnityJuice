using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "NoJuice", menuName = "CrawfisSoftware/Juice/No-op")]
    public class NoOpJuice : JuiceScriptableAbstract
    {
        public override IEnumerator Play(MonoBehaviour _)
        {
            yield break;
        }
    }
}