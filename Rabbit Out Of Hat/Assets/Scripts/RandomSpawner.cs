using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [Header("Setup")]
    public Hole[] holePoints;              
    public GameObject rabbitPrefab;
    public GameObject hedgehogPrefab;

    public enum Difficulty { Easy, Medium, Hard }
    public Difficulty currentDifficulty = Difficulty.Medium;

    private float spawnInterval;
    private float animalLifetime;

    void Start()
    {
        SetDifficulty(currentDifficulty);
        InvokeRepeating(nameof(SpawnRandomAnimal), 1f, spawnInterval);
    }

    void SetDifficulty(Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                spawnInterval = 2.0f;
                animalLifetime = 3.0f;
                break;
            case Difficulty.Medium:
                spawnInterval = 1.2f;
                animalLifetime = 2.0f;
                break;
            case Difficulty.Hard:
                spawnInterval = 0.7f;
                animalLifetime = 1.2f;
                break;
        }
    }

    void SpawnRandomAnimal()
    {
        if (holePoints.Length == 0) return;

        int index = Random.Range(0, holePoints.Length);
        Hole hole = holePoints[index];

        if (hole == null)
        {
            Debug.LogWarning($"[ERROR] holePoints[{index}] is null!");
            return;
        }

        GameObject prefab = Random.value < 0.5f ? rabbitPrefab : hedgehogPrefab;
        GameObject spawned = hole.Spawn(prefab);

        if (spawned != null)
        {
            Destroy(spawned, animalLifetime);
        }
    }
}
