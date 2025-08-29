using UnityEngine;

public class WebProjectile : MonoBehaviour
{
    public int damage = 5;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.GetComponent<ArcherHealth>() != null)
            {
                collision.GetComponent<ArcherHealth>().Damage();
                collision.GetComponent<ArcherHealth>().ArchercurrentHealth -= (damage); 
            }
            if (collision.GetComponent<SwordsmanHealth>() != null)
            {
                collision.GetComponent<SwordsmanHealth>().Damage();
                collision.GetComponent<SwordsmanHealth>().SwordscurrentHealth -= (damage); 
            }
            Destroy(gameObject);
        }
    }
}