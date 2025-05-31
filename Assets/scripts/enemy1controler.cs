using UnityEngine;

public class enemy1controler : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;

    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(t, 1f));
    }
}
