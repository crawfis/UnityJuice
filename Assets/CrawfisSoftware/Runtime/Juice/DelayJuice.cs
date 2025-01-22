using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "DelayJuice", menuName = "CrawfisSoftware/Juice/Delay Juice")]
    public class DelayJuice : JuiceScriptableAbstract
    {
        public float _delay = 0.0f;

        public override IEnumerator Play(MonoBehaviour context)
        {
            yield return new WaitForSeconds(_delay * _juiceTimeScale);
        }
    }
}