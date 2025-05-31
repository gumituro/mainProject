using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
