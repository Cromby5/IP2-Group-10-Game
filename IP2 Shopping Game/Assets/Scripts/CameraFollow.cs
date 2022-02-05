using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target; // Target we want to follow

    [SerializeField] [Range(0.01f,1f)] // A Slider to control the Smooth speed of the camera
    private float smoothSpeed = 0.125f;

    [SerializeField] private Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }

}
