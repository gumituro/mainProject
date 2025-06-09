using UnityEngine;

public class DestroyOnPlayerHit : MonoBehaviour
{
    public AudioClip destroySound;
    private AudioSource audioSource;
    private Animator animator;

    private bool hasCollided = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        string targetLayer = LayerMask.LayerToName(collision.gameObject.layer);
        if (targetLayer == "PlayerArcher" || targetLayer == "PlayerSwordsman")
        {
            hasCollided = true;
            
            if (audioSource != null && destroySound != null)
                audioSource.PlayOneShot(destroySound);

            
            Destroy(gameObject, 0.5f);
        }
    }
}