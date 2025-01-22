using CrawfisSoftware.AssetManagement;
using CrawfisSoftware.Juice;
using CrawfisSoftware.WaitEnumerable;

using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Spawners
{
    internal enum WaitType
    {
        WaitForSeconds,
        WaitForSpaceKey,
        NoWait
    }
    public class SpawnerJuiceReplay : InstanceTracker
    {
        [SerializeField] private JuiceScriptableAbstract _juiceSettings;
        [SerializeField] private float _spawnInterval = 0.3f;
        [SerializeField] private float _juiceTimeScale = 1f;
        [SerializeField] private WaitType _waitType = WaitType.NoWait;
        [SerializeField] private int _replayCountAtATime = 1;

        private Dictionary<GameObject, (int, JuiceScriptableAbstract)> _juiceList = new Dictionary<GameObject, (int, JuiceScriptableAbstract)>();
        public IEnumerable TimingControlYield { get; set; }

        private void Awake()
        {
            InstantiationSingleton.ResetInstanceCount();
        }
        public void AddJuice()
        {
            _juiceList.Clear();
            foreach (var (gameObject, sortOrder) in this.GetActiveInstances())
            {
                //var juice = Instantiate<JuiceAbstract>(_juiceSettings);
                JuiceScriptableAbstract juice = JuicePlayer.InstantiateJuice(gameObject, _juiceSettings, _juiceTimeScale);
                if (!_juiceList.ContainsKey(gameObject)) _juiceList.Add(gameObject, (sortOrder, juice));
                // Replace the Juice. Use a composite juice if you want multiple effects (or multiple JuiceSpawners).
                _juiceList[gameObject] = (sortOrder, juice);
            }
        }

        public void DisableAll()
        {
            foreach (var (gameObject, _) in this.GetActiveInstances())
            {
                gameObject.SetActive(false);
            }
        }

        public void EnableAll()
        {
            foreach (var (gameObject, _) in this.GetActiveInstances())
            {
                gameObject.SetActive(true);
            }
        }

        public void PlayAll()
        {
            DisableAll();
            PlayFrom();
        }

        public void PlayFrom(int spawnOrder = 0)
        {
            StartCoroutine(PlayInterval(spawnOrder, this.instances[instances.Count - 1].instanceOrder));
        }

        public IEnumerator PlayInterval(int first, int last)
        {
            switch (_waitType)
            {
                case WaitType.WaitForSeconds:
                    TimingControlYield = new WaitForSecondsEnumerable(_spawnInterval);
                    break;
                case WaitType.WaitForSpaceKey:
                    var keyPress = this.gameObject.AddComponent<WaitForKeyPressEnumerable>();
                    keyPress.Key = KeyCode.Space;
                    TimingControlYield = keyPress;
                    break;
                case WaitType.NoWait:
                    TimingControlYield = new NoWaitEnumerable();
                    break;
            }

            int count = 0;
            foreach (var target in _juiceList.Keys)
            {
                var (spawnOrder, juice) = _juiceList[target];
                if (spawnOrder < first)
                {
                    continue;
                }
                if (spawnOrder > last)
                {
                    break;
                }
                //target.SetActive(true); // This is done in the JuiceScriptable now.
                JuicePlayer.PlayJuice(juice, this);
                count++;
                if (count >= _replayCountAtATime)
                {
                    count = 0;
                    yield return TimingControlYield.GetEnumerator();
                }
            }
            yield return null;
        }
    }
}