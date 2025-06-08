using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SwordsPickUp : MonoBehaviour
{
    public bool isHealthDrop;
    public bool isDamageDrop;
    public bool isKey;
    public int boostAmount = 2;
    public float boostDuration = 2f;
    private bool isCollected = false;


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
            SwordmanController playerAttack = other.GetComponent<SwordmanController>();

            if (playerAttack != null)
            {

                if (isHealthDrop)
                {
                    isCollected = true;
                    AudioManager.instance.PlaySFX(5);
                    Destroy(gameObject);

                    if (SwordsmanHealth.instance.SwordscurrentHealth != 30 && SwordsmanHealth.instance.SwordscurrentHealth != 20 && SwordsmanHealth.instance.SwordscurrentHealth != 10)

                    {
                        SwordsmanHealth.instance.heal();
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
