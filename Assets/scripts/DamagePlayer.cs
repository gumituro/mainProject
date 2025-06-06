using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            //FindFirstObjectByType<HealthControler>().Damage();
            // HealthControler.instance.Damage(); 
=======
            HealthControler health = other.GetComponent<HealthControler>();
            if (health != null)
            {
                health.Damage();
            }
>>>>>>> Stashed changes
        }
    }
}