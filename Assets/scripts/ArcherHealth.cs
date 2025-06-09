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

    // Update is called once per frame
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
                Debug.Log("Archer Died!"); //dead anim isnt applied
                anim.SetTrigger("death");

            }
        }
    }
    void die()
    {
                        StartCoroutine(RestartScene());

    }
    void Update()
    {

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

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(10 * Time.deltaTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

