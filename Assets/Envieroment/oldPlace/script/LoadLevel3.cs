using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel3 : MonoBehaviour
{
    public string sceneName = "level3";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}