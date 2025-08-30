using UnityEngine;

public class ChunkLoaderWithRandomTeleport : MonoBehaviour
{
    public GameObject caveChunk;
    public Transform caveTeleportTarget;

    public GameObject ancientAndSkyChunk;
    public Transform ancientTeleportTarget;

    private GameObject selectedChunk = null;
    private Transform selectedTeleportTarget = null;

    private bool hasSelected = false; // آیا چانک تصادفی انتخاب شده؟

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        
        if (!hasSelected)
        {
            int randomIndex = Random.Range(0, 2);
            if (randomIndex == 0)
            {
                selectedChunk = caveChunk;
                selectedTeleportTarget = caveTeleportTarget;
            }
            else
            {
                selectedChunk = ancientAndSkyChunk;
                selectedTeleportTarget = ancientTeleportTarget;
            }

            
            if (selectedChunk != null)
                selectedChunk.SetActive(true);

            hasSelected = true; 
        }

        // تله‌پورت بازیکن به چانک انتخاب شده
        if (selectedTeleportTarget != null)
            other.transform.position = selectedTeleportTarget.position;
    }
}