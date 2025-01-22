using UnityEngine;
using System.ComponentModel;
using System;



#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CrawfisSoftware.AssetManagement
{
    internal static class InstantiationSingleton
    {
        public static int InstanceCount { get; private set; } = 0;
        public static event Action<GameObject, int> OnInstanceCreated;
        public static GameObject CreateNewInstance(GameObject prefab, bool _createPrefabs = false)
        {
            GameObject instance = null;
#if UNITY_EDITOR
            if (_createPrefabs)
                // Note: This will not work if called from Awake or OnEnable.
                instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            else
                instance = GameObject.Instantiate(prefab);
#else
            instance = Instantiate(prefab);
#endif
            OnInstanceCreated?.Invoke(instance, InstanceCount++);
            return instance;
        }
        public static void ResetInstanceCount()
        {
            InstanceCount = 0;
        }
    }
}