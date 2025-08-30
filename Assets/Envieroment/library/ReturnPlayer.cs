using UnityEngine;

public class ResetPlayerOnHit : MonoBehaviour
{
    public Transform boundaryPoint; // نقطه‌ای که بازیکن برگردد

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // بازگرداندن بازیکن به نقطه مشخص
            other.transform.position = boundaryPoint.position;

            // اگر Rigidbody2D دارد، سرعتش را هم صفر کنیم
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}