using UnityEngine;

namespace CrawfisSoftware.Audio
{
    internal class SimpleAudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        public static SimpleAudioManager Instance { get; internal set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void PlayAudio(AudioClip audioClip, Vector3 position)
        {
            _audioSource.transform.position = position;
            _audioSource.clip = audioClip;
            _audioSource.pitch = Random.Range(0.9f, 1.5f);
            //_audioSource.PlayOneShot(audioClip);
            _audioSource.Play();
        }
    }
}