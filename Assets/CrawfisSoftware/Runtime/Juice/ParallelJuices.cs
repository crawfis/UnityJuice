using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "ParallelJuices", menuName = "CrawfisSoftware/Juice/Parallel Juices")]
    public class ParallelJuices : JuiceAbstract
    {
        [SerializeField] private List<JuiceAbstract> _juices;

        private MonoBehaviour _coRoutineHandler;
        private int _counter = 0;

        public override IEnumerator Play(MonoBehaviour context)
        {
            _coRoutineHandler = context;
            foreach (var juiceTemplate in _juices)
            {
                var juice = Instantiate(juiceTemplate);
                juice._target = _target;
                juice._juiceTimeScale = _juiceTimeScale;
                var juiceCoRoutine = _coRoutineHandler.StartCoroutine(IncrementCounterAndPlay(juice));
            }
            yield return WaitForAllJuices();
        }

        private IEnumerator WaitForAllJuices()
        {
            while (true)
            {
                if (_counter == 0)
                {
                    yield break;
                }
                yield return null;
            }
        }
        private IEnumerator IncrementCounterAndPlay(JuiceAbstract juice)
        {
            _counter++;
            yield return juice.Play(_coRoutineHandler);
            _counter--;
        }
    }
}