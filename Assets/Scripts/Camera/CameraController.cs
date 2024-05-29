using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float smoothSpeed = 0.125f;
    private Vector3 offset;

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
        }
    }
}
