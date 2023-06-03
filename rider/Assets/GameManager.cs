using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject objects;
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs
    private List<Transform> _blocks;
    public bool isSpawningEnabled = true;
    public GameObject coinPrefab;

    void Start()
    {
        InvokeRepeating("CreateObjects", 0, 1f); // Изменяем интервал на 1 секунду
        _blocks = new List<Transform>();
    }

    private void Update()
    {
        if (!isSpawningEnabled)
            return;

        foreach (Transform block in _blocks)
        {
            if (block.localPosition.x < -30)
            {
                Destroy(block.gameObject);
                _blocks.Remove(block);
                break;
            }
        }
    }


    private void CreateObjects()
    {
        if (isSpawningEnabled)
        {
            GameObject sceneParent = new GameObject("SceneParent");
            GameObject scenePrefab = Instantiate(objects, new Vector3(-5.8f, 3.89f, 0), Quaternion.identity, sceneParent.transform);
            _blocks.Add(sceneParent.transform);

            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            GameObject obstaclePrefab = Instantiate(obstaclePrefabs[randomIndex], GetRandomPositionWithinBounds(scenePrefab), Quaternion.identity, scenePrefab.transform);
            _blocks.Add(obstaclePrefab.transform);

            // Spawn coin
            GameObject coinObject = Instantiate(coinPrefab, GetRandomPositionWithinBounds(scenePrefab), Quaternion.identity, scenePrefab.transform);
            _blocks.Add(coinObject.transform);
        }
    }

    private Vector3 GetRandomPositionWithinBounds(GameObject scenePrefab)
    {
        // Get the bounds of the children objects within the scene prefab
        Renderer[] childRenderers = scenePrefab.GetComponentsInChildren<Renderer>();
        Bounds bounds = new Bounds(scenePrefab.transform.position, Vector3.zero);
        foreach (Renderer childRenderer in childRenderers)
        {
            bounds.Encapsulate(childRenderer.bounds);
        }

        // Generate random coordinates within the bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);

        // Return the random position
        return new Vector3(randomX, -3.87f, 0);
    }

    public void StopMovement()
    {
        // Implement your stop movement logic here
    }
}


