
using System;
using Unity.Cinemachine.Samples;
using Unity.VisualScripting;
using UnityEngine;


public class DangerArea : MonoBehaviour
{
    public enemy2controler enemy2Controler;
    public static DangerArea instance;
    public Transform target;
    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.transform.position.x > gameObject.transform.position.x)
            {
                enemy2Controler.ViewIsRight = true;
            }
            else
            {
                enemy2Controler.ViewIsRight = false;
            }


            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.transform == target)
        {
            target = null;
        }
    }


}