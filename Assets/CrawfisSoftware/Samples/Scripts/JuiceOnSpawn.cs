using UnityEngine;
using CrawfisSoftware.AssetManagement;
using System;
using CrawfisSoftware.Juice;
using System.Collections;

namespace CrawfisSoftware.Spawners
{
    public class JuiceOnSpawn : MonoBehaviour
    {
        [SerializeField] private JuiceScriptableAbstract _juice;
        void OnEnable()
        {
            InstantiationSingleton.OnInstanceCreated += OnInstantiation;
        }

        private void OnDisable()
        {
            InstantiationSingleton.OnInstanceCreated -= OnInstantiation;
        }

        private void OnInstantiation(GameObject instance, int instanceCount)
        {
            var juice = JuicePlayer.InstantiateJuice(instance, _juice, 1);
            StartCoroutine(ShowJuice(juice));
        }
        private IEnumerator ShowJuice(JuiceScriptableAbstract juice)
        {
            yield return null;
            JuicePlayer.PlayJuice(juice, this);
        }
    }
}