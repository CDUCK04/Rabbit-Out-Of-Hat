using UnityEngine;

public class HandController : MonoBehaviour
{
    [Header("Hand Settings")]
    public Transform handTransform;        
    public float handHeight = 1f;         
    public float moveSpeed = 10f;          
    public LayerMask tableLayer;           

    void Update()
    {
        MoveHandToMouse();
    }

    void MoveHandToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, tableLayer))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = handHeight;

            handTransform.position = Vector3.Lerp(handTransform.position, targetPosition, Time.deltaTime * moveSpeed);
        }
    }
}
