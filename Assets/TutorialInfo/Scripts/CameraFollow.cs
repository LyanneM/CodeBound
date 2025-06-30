using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag your Player here
    public Vector3 offset = new Vector3(0f, 2f, -6f);
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Follow rotation too
            Vector3 desiredPosition = target.position + target.TransformDirection(offset);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.LookAt(target); // Always look at player
        }
    }
}
