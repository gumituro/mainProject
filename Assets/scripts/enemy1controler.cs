using UnityEngine;

public class enemy1controler : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;

    private Vector3 posA;
    private Vector3 posB;
    private bool movingToB = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        posA = pointA.position;
        posB = pointB.position;

        // گرفتن SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    void Update()
    {
        Vector3 target = movingToB ? posB : posA;

        // حرکت به سمت هدف
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // چک کردن اتمام مسیر
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingToB = !movingToB;
        }

        // چرخش اسپریت در جهت حرکت
        if (target.x > transform.position.x)
        {
            spriteRenderer.flipX = false; // نگاه به راست
        }
        else if (target.x < transform.position.x)
        {
            spriteRenderer.flipX = true; // نگاه به چپ
        }
    }
}
