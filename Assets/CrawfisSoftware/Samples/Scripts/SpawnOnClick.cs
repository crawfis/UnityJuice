using CrawfisSoftware.AssetManagement;

using UnityEngine;

namespace CrawfisSoftware.Spawners
{
    internal class SpawnOnClick : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _yMin = 0.0f;
        [SerializeField] private float _yMax = 10.0f;
        [SerializeField] private bool _setStartActive = true;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (!hit.collider.gameObject.CompareTag("Ground"))
                    {
                        return;
                    }
                    //Debug.Break(); // Pauses the Unity Editor.
                    var instance = InstantiationSingleton.CreateNewInstance(_prefab);
                    Vector3 worldPosition = hit.point;
                    worldPosition.y = Random.Range(_yMin, _yMax);
                    instance.transform.position = worldPosition;
                    instance.SetActive(_setStartActive);
                }
            }
        }
    }
}