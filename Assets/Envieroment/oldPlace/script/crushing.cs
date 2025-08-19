using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class crushing : MonoBehaviour
{
    public Transform topPart;
    public Transform bottomPart;
    public float crushThreshold = 0.5f;

    private bool isRestarting = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float playerY = other.transform.position.y;
            float topY = topPart.position.y;
            float bottomY = bottomPart.position.y;

            float distance = topY - bottomY;

//             if (distance <= crushThreshold && playerY < topY && playerY > bottomY)
//             {
//                 PlayerHealth health = other.GetComponent<PlayerHealth>();
//                 if (health != null)
//                 {
//                     health.TakeDamage(1);
//
// //if there is no more health, reset
//                     if (health.currentHealth <= 0)
//                     {
//                         RestartLevelOnce();
//                     }
//                 }
//             }
        }
    }


    private void RestartLevelOnce()
    {
        if (!isRestarting)
        {
            isRestarting = true;
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

