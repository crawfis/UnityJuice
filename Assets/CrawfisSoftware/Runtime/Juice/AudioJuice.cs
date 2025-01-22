using CrawfisSoftware.Audio;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "AudioJuice", menuName = "CrawfisSoftware/Juice/Audio Juice")]
    public class AudioJuice : JuiceAbstract
    {
        [SerializeField] private List<AudioClip> _audioClips;
        [SerializeField] private float _delay = 0.0f;

        public override IEnumerator Play(MonoBehaviour _)
        {
            Vector3 position = _target.transform.localPosition;
            if (_target == null)
            {
                Debug.LogError("Target is null");
                yield break;
            }
            yield return new WaitForSeconds(_delay * _juiceTimeScale);
            var audioClip = _audioClips[Random.Range(0, _audioClips.Count)];
            SimpleAudioManager.Instance.PlayAudio(audioClip, position);
            yield return null;
        }
    }
}