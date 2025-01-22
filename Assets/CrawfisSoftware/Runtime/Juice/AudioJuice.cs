using CrawfisSoftware.Audio;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Juice
{
    [CreateAssetMenu(fileName = "AudioJuice", menuName = "CrawfisSoftware/Juice/Audio Juice")]
    public class AudioJuice : JuiceScriptableAbstract
    {
        [SerializeField] private List<AudioClip> _audioClips;

        public override IEnumerator Play(MonoBehaviour context)
        {
            Vector3 position = _target.transform.localPosition;
            var audioClip = _audioClips[Random.Range(0, _audioClips.Count)];
            SimpleAudioManager.Instance.PlayAudio(audioClip, position);
            yield return null;
        }
    }
}