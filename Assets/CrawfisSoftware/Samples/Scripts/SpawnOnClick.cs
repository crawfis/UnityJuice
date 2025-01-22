using CrawfisSoftware.AssetManagement;

using UnityEngine;

namespace Assets.CrawfisSoftware.Samples.Scripts
{
    internal class SpawnOnClick : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10.0f;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                var instance = InstantiationSingleton.CreateNewInstance(_prefab);
                instance.transform.position = worldPosition;
            }
        }
    }
}