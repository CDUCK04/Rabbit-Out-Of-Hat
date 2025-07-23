using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Hole[] holePoints;      // Array of empty GameObjects in scene
    public GameObject rabbitPrefab;      // Sphere
    public GameObject hedgehogPrefab;    // Cube
    public float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 1f, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, holePoints.Length);
        Hole hole = holePoints[index];

        if (hole == null)
        {
            Debug.LogError($"[ERROR] holePoints[{index}] is null! Check your Inspector.");
            return;
        }

        GameObject prefab = (Random.value < 0.5f) ? rabbitPrefab : hedgehogPrefab;
        hole.Spawn(prefab);

    }
}
