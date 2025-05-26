using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 2;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // برخورد با دشمن 
        Destroy(gameObject);
    }
}
