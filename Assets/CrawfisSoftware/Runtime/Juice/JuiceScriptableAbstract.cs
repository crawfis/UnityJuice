using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    public abstract class JuiceScriptableAbstract : ScriptableObject, IJuice
    {
        public GameObject _target;
        public float _juiceTimeScale = 1f;

        public abstract IEnumerator Play(MonoBehaviour context);
    }
}