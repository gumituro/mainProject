using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ArcherPickUp : MonoBehaviour
{
    public bool isHealthDrop;
    public bool isDamageDrop;
    bool isCollected = false;

    public int boostAmount = 2; // چقدر اتک قوی‌تر بشه
    public float boostDuration = 10f; //چند ثانیه قوی تر شه

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            ArcherController playerAttack = other.GetComponent<ArcherController>();
            if (playerAttack != null)
            {
                if (isHealthDrop)
                    isCollected = true;
                Destroy(gameObject);

                {
                    if (ArcherHealth.instance.ArchercurrentHealth != 30 && ArcherHealth.instance.ArchercurrentHealth != 20 && ArcherHealth.instance.ArchercurrentHealth != 10)

                    {
                        ArcherHealth.instance.heal();
                    }


                }
                if (isDamageDrop)
                {
                    isCollected = true;
                    playerAttack.StartCoroutine(playerAttack.TemporaryDamageBoost(boostAmount, boostDuration));
                    gameObject.SetActive(false); 

                }

            }
        }
    }
}
