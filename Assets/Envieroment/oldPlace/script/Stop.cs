using UnityEngine;

public class Stop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject stopObject = GameObject.FindGameObjectWithTag("Stop");
            if (stopObject != null)
            {
                stopObject.SetActive(false);
            }
        }
    }
}