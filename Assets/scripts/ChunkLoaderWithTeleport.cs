using UnityEngine;

public class ChunkLoaderWithTeleport : MonoBehaviour
{
    public GameObject chunkToActivate;
    public Transform teleportTarget;

    private bool hasActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasActivated) return;

        if (other.CompareTag("Player"))
        {
            if (chunkToActivate != null)
                chunkToActivate.SetActive(true);
            
            if (teleportTarget != null)
                other.transform.position = teleportTarget.position;

            hasActivated = true;
        }
    }
}