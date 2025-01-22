using System.Collections;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "EffectJuice", menuName = "CrawfisSoftware/Juice/Vfx Juice")]
    public class SpawnEffectJuice : JuiceScriptableAbstract
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _sizeScale = 1f;
        [SerializeField] private Vector3 _offset = Vector3.zero;

        public override IEnumerator Play(MonoBehaviour context)
        {
            GameObject effect = Instantiate(_prefab, _target.transform.position + _offset, Quaternion.identity);
            effect.transform.localScale *= _sizeScale;
            //effect.transform.SetParent(_target.transform, true);
            float time = 0;
            while (time < _duration)
            {
                time += _juiceTimeScale * Time.deltaTime;
                yield return null;
            }
            DestroyImmediate(effect);
        }
    }
}