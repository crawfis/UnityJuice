using System.Collections;
using System.Linq;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "RotationJuice", menuName = "CrawfisSoftware/Juice/Rotation Juice")]
    public class RotateAboutJuice : JuiceAbstract
    {
        [SerializeField] private AnimationCurve _rotationCurve;
        [SerializeField] private Vector3 _rotationAxis = Vector3.up;

        public override IEnumerator Play(MonoBehaviour _)
        {
            if (_target == null)
            {
                Debug.LogError("Target is null");
                yield break;
            }

            Quaternion startingRotation = _target.transform.localRotation;
            float time = 0;
            while (time < _rotationCurve.keys.Last().time)
            {
                float rotationAmount = _rotationCurve.Evaluate(time);
                var rotation = Quaternion.AngleAxis(rotationAmount, _rotationAxis);
                time += _juiceTimeScale * Time.deltaTime;
                _target.transform.localRotation = rotation;
                yield return null;
            }
            _target.transform.localRotation = startingRotation;
        }
    }
}