using UnityEngine;

public class Hole : MonoBehaviour
{
    private GameObject currentOccupant;

    // Call this when you want to spawn something in this hole
    public void Spawn(GameObject prefab)
    {
        Clear(); // Remove whatever was here before

        currentOccupant = Instantiate(prefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
    }

    public void Clear()
    {
        if (currentOccupant != null)
        {
            Destroy(currentOccupant);
            currentOccupant = null;
        }
    }
}
