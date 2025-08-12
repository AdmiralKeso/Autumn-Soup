using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // The player to follow
    public float smoothing = 5f;      // Camera smoothing
    public Tilemap FloorTilemap;      // Floor tilemap
    private Vector3 offset;
    private float minX, maxX, minY, maxY;
    private float halfHeight, halfWidth;
    private float tileSize = 1f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: Target not assigned!");
            return;
        }

        if (FloorTilemap == null)
        {
            Debug.LogError("CameraFollow: FloorTilemap not assigned!");
            return;
        }

        offset = transform.position - target.position;

        Camera cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;

        // Get tilemap cell bounds (in grid coordinates)
        BoundsInt cellBounds = FloorTilemap.cellBounds;

        // Get world position of bottom-left corner of tilemap
        Vector3 min = FloorTilemap.CellToWorld(cellBounds.min);

        // Map size (28x16)
        minX = min.x + halfWidth;
        maxX = min.x + 28 - halfWidth;

        minY = min.y + halfHeight;
        maxY = min.y + 16 - halfHeight;

        // Handle small map case: if map smaller than camera view, lock camera center
        if (minX > maxX)
            minX = maxX = (min.x + maxX) / 2;

        if (minY > maxY)
            minY = maxY = (min.y + maxY) / 2;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPos = target.position + offset;

        float clampedX = Mathf.Clamp(targetPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPos.y, minY, maxY);

        Vector3 clampedPos = new Vector3(clampedX, clampedY, targetPos.z);

        transform.position = Vector3.Lerp(transform.position, clampedPos, smoothing * Time.deltaTime);
    }
}