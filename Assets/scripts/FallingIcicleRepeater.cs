using UnityEngine;

public class FallingIcicleRepeater : MonoBehaviour
{
    public float damage = 3f;
    public float fallInterval = 5f;
    public float respawnDelay = 10f;
    public float preFallDelay = 0.5f; 

    public Vector2 originalPosition;

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public AudioClip preFallSound;
    public AudioClip impactSound;

    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        originalPosition = transform.position;
        InvokeRepeating(nameof(PreFallWarning), fallInterval, fallInterval);
    }

    void PreFallWarning()
    {
        if (!isFalling && gameObject.activeInHierarchy)
        {
            if (preFallSound != null)
                audioSource.PlayOneShot(preFallSound);
            
            Invoke(nameof(StartFalling), preFallDelay);
        }
    }

    void StartFalling()
    {
        rb.gravityScale = 0.5f;
        isFalling = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        string targetLayer = LayerMask.LayerToName(collision.gameObject.layer);

        if (targetLayer == "PlayerArcher" || targetLayer == "PlayerSwordsman")
        {
            HealthControler health = collision.gameObject.GetComponent<HealthControler>();
            if (health != null)
                health.Damage();
        }

        if (impactSound != null && gameObject.activeInHierarchy)
            audioSource.PlayOneShot(impactSound);

        StopFalling();
    }

    void StopFalling()
    {
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        col.enabled = false;
        spriteRenderer.enabled = false;
        isFalling = false;

        Invoke(nameof(Respawn), respawnDelay);
    }

    void Respawn()
    {
        transform.position = originalPosition;
        col.enabled = true;
        spriteRenderer.enabled = true;
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        isFalling = false;
    }
}
