using UnityEngine;

public class SharedCameraFollow : MonoBehaviour
{
    public Transform[] players;    
    public Vector3 offset;          
    public float smoothTime = 0.3f;

    public Vector2 minBounds;       
    public Vector2 maxBounds;       
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (players.Length == 0) return;

        Vector3 center = Vector3.zero;
        foreach (Transform player in players)
            center += player.position;
        center /= players.Length;

        Vector3 targetPos = center + offset;

        targetPos.x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);
        targetPos.z = offset.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}