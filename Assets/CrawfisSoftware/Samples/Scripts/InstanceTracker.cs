using System.Collections.Generic;

using UnityEngine;

namespace CrawfisSoftware.AssetManagement
{
    public class InstanceTracker : MonoBehaviour
    {
        protected List<(GameObject gameObject, int instanceOrder)> instances = new List<(GameObject, int)>();

        public IEnumerable<(GameObject, int)> GetActiveInstances()
        {
            foreach (var instance in instances)
            {
                if (instance.gameObject != null && instance.gameObject.activeInHierarchy)
                {
                    yield return instance;
                }
            }
        }

        protected virtual void OnEnable()
        {
            InstantiationSingleton.OnInstanceCreated += OnInstanceCreated;
        }

        protected virtual void OnDisable()
        {
            instances.Clear();
            InstantiationSingleton.OnInstanceCreated -= OnInstanceCreated;
        }

        protected virtual void OnInstanceCreated(GameObject instance, int count)
        {
            instances.Add((instance, count));
        }
    }
}