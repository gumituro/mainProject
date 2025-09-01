using UnityEngine;

public class MoveUpDown : MonoBehaviour
{
    [Header("Movement")]
    public Transform pointA;  
    public Transform pointB;  
    public float speed = 2f;

    [Header("Player Reset Settings")]
    public Transform playerResetPoint;
    public int damage = 1;        

    private Transform target; 

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        if (pointA == null || pointB == null) return;


        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (other.GetComponent<ArcherHealth>() != null)
            {
                ArcherHealth archer = other.GetComponent<ArcherHealth>();
                archer.Damage();
                archer.ArchercurrentHealth -= damage;
            }
            else if (other.GetComponent<SwordsmanHealth>() != null)
            {
                SwordsmanHealth sword = other.GetComponent<SwordsmanHealth>();
                sword.Damage();
                sword.SwordscurrentHealth -= damage;
            }


            if (playerResetPoint != null)
            {
                other.transform.position = playerResetPoint.position;


                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
            }
        }
    }
}