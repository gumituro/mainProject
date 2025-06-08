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

        var swordsman = other.GetComponent<SwordsmanHealth>();
        if (swordsman != null)
        {
            swordsman.Damage();
            return;
        }

            
            anim.SetTrigger("attack");

            var swordsman = other.GetComponent<SwordsmanHealth>();
            if (swordsman != null)
            {
                swordsman.Damage();
                return;
            }

            var Archer = other.GetComponent<ArcherHealth>();
            if (Archer != null)
            {
                Archer.Damage();
                return;
            }
        }

    }
}

