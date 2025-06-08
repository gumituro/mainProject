using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;

    private Vector3 posA;
    private Vector3 posB;
    private bool movingToB = true;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        
        posA = pointA.position;// ذخیره کردن مختصات اولیه نقاط
        posB = pointB.position;
    }

    void Update()
    {
        if (movingToB)
        {
            spriteRenderer.flipX = false;
        }
        else if (!movingToB)
        {
            spriteRenderer.flipX = true; 
        }

        Vector3 target = movingToB ? posB : posA;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingToB = !movingToB;
        }
    }
}
