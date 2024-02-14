using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera should follow (assign the dice transform here)
    public Vector3 offset; // The offset distance between the camera and the target

    void Start()
    {
        // Calculate the initial offset based on current positions
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the target while maintaining the offset
        transform.position = target.position + offset;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}