using UnityEngine;

public class PlayerTriggerNotifier : MonoBehaviour
{
    public int playerIndex; // 0 برای بازیکن 1، 1 برای بازیکن 2
    public TwoPlayerChunkManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChunkEntrance"))
        {
            manager.PlayerEnter(transform, playerIndex);
        }

        if (other.CompareTag("ChunkEnd"))
        {
            manager.PlayerReachedEnd(transform, playerIndex);
        }
    }
}