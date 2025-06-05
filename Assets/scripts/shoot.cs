using UnityEngine;

public class shoot : MonoBehaviour
{
    // public float attackSpeed = 1f;
    //  by dedault attackdamage for archer is 2 and forawordsman is 1
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            var swordsman = other.GetComponent<SwordsmanHealth>();
            var Archer = other.GetComponent<ArcherHealth>();

            if (swordsman != null)
            {
                swordsman.Damage();
                UIcontrollerSword.instance.UpdateHealthDisplay();
                Debug.Log("bat hitted swordsman!!!");
                Destroy(gameObject);

                return;
            }

            else if (Archer != null)
            {
                Archer.Damage();
                UIcontrollerArcher.instance.UpdateHealthDisplay();
                Debug.Log("bat hitted swordsman!!!");
                Destroy(gameObject); 
                return;
            }

        }
    }
}
