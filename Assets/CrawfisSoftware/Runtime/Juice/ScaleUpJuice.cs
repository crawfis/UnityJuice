using System.Collections;
using System.Linq;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "ScaleUpJuice", menuName = "CrawfisSoftware/Juice/Scale Juice")]
    public class ScaleUpJuice : JuiceAbstract
    {
        [SerializeField] private AnimationCurve _scaleCurve;

        public override IEnumerator Play(MonoBehaviour _)
        {
            Vector3 startingScale = _target.transform.localScale;
            float time = 0;
            if (_target == null)
            {
                Debug.LogError("Target is null");
                yield break;
            }
            while (time < _scaleCurve.keys.Last().time)
            {
                Vector3 scale = startingScale * _scaleCurve.Evaluate(time);
                time += _juiceTimeScale * Time.deltaTime;
                _target.transform.localScale = scale;
                yield return null;
            }
            _target.transform.localScale = startingScale;
        }
    }
}