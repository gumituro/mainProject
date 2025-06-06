using System.Collections;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public static levelManager instance;
    public float waitToRespawn;
    public int GemCollected = 0 ;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
    // public void respawnPlayer() //deactive other respawns in any scripts!!
    // {

    // }
//     IEnumerator respawn()
//     {
//     }
// }
