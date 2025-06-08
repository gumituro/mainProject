using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArcherHealth : MonoBehaviour
{
    public static ArcherHealth instance;
    public float ArchermaxHealth= 30;
    public float ArchercurrentHealth;
    public Animator anim;


    private float ArcherdamageCooldown = 1f;
    private float ArcherlastDamageTime;

    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();

        ArchercurrentHealth = ArchermaxHealth;
        ArcherlastDamageTime = -ArcherdamageCooldown;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Damage()
    {
        anim.SetTrigger("hurt");

        if (Time.time - ArcherlastDamageTime >= ArcherdamageCooldown)
        {
            ArchercurrentHealth -= 2;
            ArcherlastDamageTime = Time.time;
            UIcontrollerArcher.instance.UpdateHealthDisplay();

            if (ArchercurrentHealth <= 0)
            {
                ArchercurrentHealth = 0;
                anim.SetTrigger("death");
                Debug.Log("Archer Died!"); //dead anim isnt applied

                // StartCoroutine(RestartScene());

            }
        }
    }

    public void heal()
    {
        Debug.Log("Archer healed");

        if (ArchercurrentHealth < 30 && ArchercurrentHealth > 20)
        {
            ArchercurrentHealth += 5;

            if (ArchercurrentHealth > 30)
            {
                ArchercurrentHealth = 30;
            }

        }
        if (ArchercurrentHealth > 10 && ArchercurrentHealth < 20)
        {
            ArchercurrentHealth += 5;
            if (ArchercurrentHealth > 20)
            {
                ArchercurrentHealth = 20;
            }

        }
        if (ArchercurrentHealth > 0 && ArchercurrentHealth < 10)
        {
            ArchercurrentHealth += 5;
            if (ArchercurrentHealth > 10)
            {
                ArchercurrentHealth = 10;
            }
        }

        UIcontrollerArcher.instance.UpdateHealthDisplay();
    }

    // IEnumerator RestartScene()
    // {
    //     yield return new WaitForSeconds(10 * Time.deltaTime);
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }
}

