using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindFirstObjectByType<HealthControler>().Damage();
            // HealthControler.instance.Damage(); 
        }

    }
}
