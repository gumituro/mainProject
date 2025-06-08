using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public Animator anim; 

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
            anim.SetTrigger("attack");

            // AudioManager.instance.PlaySFX(2);

            var Archer = other.GetComponent<ArcherHealth>();
            var swordsman = other.GetComponent<SwordsmanHealth>();
            if (Archer != null)
            {
                Archer.Damage();
                return;
            }
            else if (swordsman != null)
            {
                swordsman.Damage();
                return;
            }
        }

    }
}

