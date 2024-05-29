using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField] private GameObject[] RoadPrefabs;

    private float ySpawn = 10;
    private float roadLength = 10;
    private int numberOfRoad = 4;

    private List<GameObject> activeTiles = new List<GameObject>();

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        for (int i = 0; i < numberOfRoad; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, RoadPrefabs.Length));
        }
    }

    private void Update()
    {
        if (playerTransform.position.y - 15 > ySpawn - (numberOfRoad * roadLength))
        {
            SpawnTile(Random.Range(0, RoadPrefabs.Length));
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(RoadPrefabs[tileIndex], transform.position + new Vector3(0, ySpawn, 0), transform.rotation);
        activeTiles.Add(go);
        ySpawn += roadLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}