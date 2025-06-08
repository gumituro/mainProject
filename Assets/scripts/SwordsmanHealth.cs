using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.AI;

public class SwordsmanHealth : MonoBehaviour
{
    public static SwordsmanHealth instance;
    public float SwordsmaxHealth= 30 ;
    public float SwordscurrentHealth;
    Animator anim;



    // public SwordmanController swordmanController;

    private float SwordsdamageCooldown = 0.8f; // زمان بین دو دمج
    private float SwordslastDamageTime;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        SwordscurrentHealth = SwordsmaxHealth;
        SwordslastDamageTime = -SwordsdamageCooldown;
    }

    // Update is called once per frame
    public void Damage()
    {
        anim.SetTrigger("hurt");

        if (Time.time - SwordslastDamageTime >= SwordsdamageCooldown)
        {
            SwordscurrentHealth--;
            SwordslastDamageTime = Time.time;

            UIcontrollerSword.instance.UpdateHealthDisplay();


            if (SwordscurrentHealth <= 0)
            {
                SwordscurrentHealth = 0;
                Debug.Log("Swordsman Died!"); //dead anim isnt applied

                // swordmanController.die();
                StartCoroutine(RestartScene());

            }
        }
    }


    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(10 * Time.deltaTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void heal()
    {



        if (SwordscurrentHealth < 30 && SwordscurrentHealth > 20)
        {
            SwordscurrentHealth += 5;

            if (SwordscurrentHealth > 30)
            {
                SwordscurrentHealth = 30;
            }

        }
        if (SwordscurrentHealth > 10 && SwordscurrentHealth < 20)
        {
            SwordscurrentHealth += 5;
            if (SwordscurrentHealth > 20)
            {
                SwordscurrentHealth = 20;
            }

        }
        if (SwordscurrentHealth > 0 && SwordscurrentHealth < 10)
        {
            SwordscurrentHealth += 5;
            if (SwordscurrentHealth > 10)
            {
                SwordscurrentHealth = 10;
            }
        }

        Debug.Log("Swordsman healed.");
        UIcontrollerSword.instance.UpdateHealthDisplay();

    }


}

