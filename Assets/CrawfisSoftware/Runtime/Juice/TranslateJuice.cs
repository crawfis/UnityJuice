using System.Collections;
using System.Linq;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "TranslateJuice", menuName = "CrawfisSoftware/Juice/Translate Juice")]
    public class TranslateJuice : JuiceScriptableAbstract
    {
        [SerializeField] private AnimationCurve _offsetCurve;
        [SerializeField] private Vector3 _animationDirection = Vector3.up;

        public override IEnumerator Play(MonoBehaviour context)
        {
            Vector3 startPosition = _target.transform.localPosition;
            float time = 0;
            while (time < _offsetCurve.keys.Last().time)
            {
                float offset = _offsetCurve.Evaluate(time);
                time += _juiceTimeScale * Time.deltaTime;
                _target.transform.localPosition = startPosition + offset * _animationDirection;
                yield return null;
            }
            _target.transform.localPosition = startPosition;
        }
    }
}