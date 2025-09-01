using UnityEngine;

public class UpDown : MonoBehaviour
{
    public Transform pointA;        
    public Transform pointB;        
    public float minSpeed = 1f;    
    public float maxSpeed = 5f;    

    private Transform target;       
    private float currentSpeed;    

    void Start()
    {
        target = pointB;
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        if (pointA == null || pointB == null) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
          
            target = (target == pointA) ? pointB : pointA;

  
            currentSpeed = Random.Range(minSpeed, maxSpeed);
        }
    }
}