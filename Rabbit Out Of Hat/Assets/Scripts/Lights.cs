using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject light;
    public Transform snapPoint;
    public Hole parentHole;
    private Animator handAnim;
    private bool handInside = false;
    private GameObject currentAnimal;
    private Transform handTransform;
    private bool hasPulled = false;

    void Start()
    {
        if (parentHole == null)
            parentHole = GetComponentInParent<Hole>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            light.SetActive(true);
            handTransform = other.transform;
            handAnim = other.GetComponent<Animator>();
            handInside = true;
            hasPulled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            light.SetActive(false);
            handInside = false;
            handTransform = null;
            currentAnimal = null;
        }
    }

    void Update()
    {
        if (handInside && !hasPulled && Input.GetMouseButtonDown(0))
        {
            if (handTransform == null || handAnim == null || parentHole == null) return;

            // Snap hand
            handTransform.position = new Vector3(snapPoint.position.x,handTransform.position.y,snapPoint.position.z);

            // Get animal
            currentAnimal = parentHole.GetCurrentOccupant();
            if (currentAnimal == null) return;

            hasPulled = true;

            // Attach animal to hand
            currentAnimal.transform.SetParent(handTransform);
            currentAnimal.transform.localPosition = new Vector3(0, -0.5f, 0);
            Rigidbody rb = currentAnimal.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            // Play animation
            if (currentAnimal.CompareTag("Rabbit"))
            {
                handAnim.Play("PickUp", -1, 0f);
                Invoke(nameof(DestroyAnimal), 1.0f);
            }
            else if (currentAnimal.CompareTag("Hedgehog"))
            {
                handAnim.Play("ShakeHand", -1, 0f);
                Invoke(nameof(DestroyAnimal), 1.0f);
            }
        }
    }

    void DestroyAnimal()
    {
        if (currentAnimal != null)
        {
            Destroy(currentAnimal);
            currentAnimal = null;
        }
    }
}
