using CrawfisSoftware.AssetManagement;

using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.Spawners
{
    internal class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabs;
        [SerializeField] private int _numberToSpawn = 100;
        [SerializeField] private GameObject _gameTemplate;
        [SerializeField] private bool _createPrefabs = true;

        private void Start()
        {
            //InstantiationSingleton.ResetInstanceCount();
            Generate();
        }
        public void Generate()
        {
            for (int i = 0; i < _numberToSpawn; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, _prefabs.Count);
                GameObject prefab = _prefabs[randomIndex];
                GameObject instance = InstantiationSingleton.CreateNewInstance(prefab, _createPrefabs);
                if (_gameTemplate != null)
                {
                    var componentsToAdd = _gameTemplate.GetComponents<Component>();
                    foreach (Component component in componentsToAdd)
                    {
                        if (component.GetType() == typeof(Transform)) continue;
                        instance.AddComponent(component.GetType());
                    }
                }
                float randomX = UnityEngine.Random.Range(-10.0f, 10.0f);
                float randomZ = UnityEngine.Random.Range(-10.0f, 10.0f);
                instance.transform.position = new Vector3(randomX, 0, randomZ);
            }
        }
    }
}