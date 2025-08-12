using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // The player to follow
    public float smoothing = 5f;      // How smoothly the camera follows

    private Vector3 offset;           // Initial offset between camera and player

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: Target not set!");
            return;
        }
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
