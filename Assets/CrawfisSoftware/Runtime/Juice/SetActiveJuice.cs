using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "SetActiveJuice", menuName = "CrawfisSoftware/Juice/SetActive Juice")]
    public class SetActiveJuice : JuiceScriptableAbstract
    {
        [SerializeField] private bool _setActive = true;

        public override IEnumerator Play(MonoBehaviour context)
        {
            _target.SetActive(_setActive);
            yield break;
        }
    }
}