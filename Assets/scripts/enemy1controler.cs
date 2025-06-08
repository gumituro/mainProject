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

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }

    void Update()
    {
        Vector3 target = movingToB ? posB : posA;

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingToB = !movingToB;
        }

        if (target.x > transform.position.x)
        {
            spriteRenderer.flipX = false; 
        }
        else if (target.x < transform.position.x)
        {
            spriteRenderer.flipX = true; 
        }
    }
}
