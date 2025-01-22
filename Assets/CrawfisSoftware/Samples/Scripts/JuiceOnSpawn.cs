using UnityEngine;
using CrawfisSoftware.AssetManagement;
using System;
using CrawfisSoftware.Juice;
using System.Collections;
public class JuiceOnSpawn : MonoBehaviour
{
    [SerializeField] private JuiceAbstract _juice;
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
    private IEnumerator ShowJuice(JuiceAbstract juice)
    {
        yield return null;
        JuicePlayer.PlayJuice(juice, this);
    }
}