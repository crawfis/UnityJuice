using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "SequentialJuices", menuName = "CrawfisSoftware/Juice/Sequential Juices")]
    internal class SequentialJuice : JuiceAbstract
    {
        [SerializeField] private List<JuiceAbstract> _juices;
        public override IEnumerator Play(MonoBehaviour context)
        {
            foreach (var juiceTemplate in _juices)
            {
                var juice = Instantiate(juiceTemplate);
                juice._target = _target;
                juice._juiceTimeScale = _juiceTimeScale;
                yield return context.StartCoroutine(juice.Play(context));
                //var coRoutine = context.StartCoroutine(juice.Play(context));
                //while (coRoutine != null) { yield return null; }
            }
        }
    }
}