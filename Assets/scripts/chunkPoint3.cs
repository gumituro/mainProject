using UnityEngine;

public class chunkPoint3 : MonoBehaviour
{
    public Transform chunkPoint1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = chunkPoint1.position;
        }
    }
}