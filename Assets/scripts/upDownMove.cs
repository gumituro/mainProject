using UnityEngine;

public class upDownMove : MonoBehaviour
{
    public Transform topPart;        // بخش بالایی ستون
    public Transform bottomPart;     // بخش پایینی ستون

    public float moveRange = 3f;     // بیشترین فاصله بین بالا و پایین
    public float speed = 1f;         // سرعت حرکت

    private Vector3 topStartPos;
    private Vector3 bottomStartPos;

    void Start()
    {
        topStartPos = topPart.localPosition;
        bottomStartPos = bottomPart.localPosition;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, moveRange);

        topPart.localPosition = topStartPos + new Vector3(0, -offset / 2f, 0);
        bottomPart.localPosition = bottomStartPos + new Vector3(0, offset / 2f, 0);
    }
}
