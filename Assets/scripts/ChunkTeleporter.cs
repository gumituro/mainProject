using System;
using UnityEngine;

public class ChunkTeleporter : MonoBehaviour
{
    public Transform chunkPoint1; // مقصد
    public Transform chunkPoint3; // موقعیت تلپورت

    public float triggerDistance = 1f; // فاصله‌ای که بازیکن باید نزدیک باشه تا تلپورت بشه

    private Transform player; // آبجکت بازیکن یا هر چیزی که باید تلپورت بشه

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        if (Vector2.Distance(player.position, chunkPoint3.position) < triggerDistance)
        {
            player.position = chunkPoint1.position;
        }
    }
}