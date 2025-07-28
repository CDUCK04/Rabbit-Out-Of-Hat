using UnityEngine;

public class Hole : MonoBehaviour
{
    private GameObject currentOccupant;

    public GameObject Spawn(GameObject prefab)
    {
        Clear();

        Vector3 spawnPosition = new Vector3(transform.position.x, 0.75f, transform.position.z);
        Quaternion spawnRotation = Quaternion.Euler(0f, 180f, 0f);

        currentOccupant = Instantiate(prefab, spawnPosition, spawnRotation);
        return currentOccupant;
    }

    public void Clear()
    {
        if (currentOccupant != null)
        {
            Destroy(currentOccupant);
            currentOccupant = null;
        }
    }

    public GameObject GetCurrentOccupant()
    {
        return currentOccupant;
    }
}
