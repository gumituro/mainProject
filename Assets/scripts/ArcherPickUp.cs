using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ArcherPickUp : MonoBehaviour
{
    public bool isHealthDrop;
    public bool isDamageDrop;
    public bool isKey;

    private bool isCollected = false;

    public int boostAmount = 2; // چقدر اتک قوی‌تر بشه
    public float boostDuration = 10f; //چند ثانیه قوی تر شه

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            ArcherController playerAttack = other.GetComponent<ArcherController>();
            if (playerAttack != null)
            {
                if (isHealthDrop)
                    isCollected = true;
                AudioManager.instance.PlaySFX(5);

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
                            AudioManager.instance.PlaySFX(4);

                    gameObject.SetActive(false);

                }
                if (isKey)
                {
                    isCollected = true;
                    levelManager.instance.GemCollected++;
                    Destroy(gameObject);
                    Debug.Log("gem collected. collected gems count: " + levelManager.instance.GemCollected);
                }


            }
        }
    }
}
