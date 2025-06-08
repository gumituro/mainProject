using UnityEngine;
public class dangerArea : MonoBehaviour
{

    public enemy2controler enemy;
    public Transform target;
    public static dangerArea instance;
    void Start()
    {
        instance = this;
    }
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (other.transform.position.x > gameObject.transform.position.x)
            {
                enemy.ViewIsRight = true;
            }
            else
            {
                enemy.ViewIsRight = false;
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