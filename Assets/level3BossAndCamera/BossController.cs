using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    public static BossController instance;

    [Header("Movement")]
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    private float currentSpeed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveDir;

    [Header("Arena Boundaries")]
    public float minX, maxX, minY, maxY; // محدوده حرکت

    [Header("Targeting")]
    private GameObject currentTarget;
    public GameObject archer;
    public GameObject swordsman;
    private bool isLockedOn = false;

    [Header("Attack")]
    public GameObject webPrefab;
    public Transform firePoint; // محل اسپاون تار
    public float webSpeed = 5f;

    [Header("Game Over UI")]
    public GameObject winPanel;
    public GameObject losePanel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentSpeed = walkSpeed;
        
        GameObject arena = GameObject.Find("Arena");
        if (arena != null && arena.GetComponent<BoxCollider2D>() != null)
        {
            Bounds b = arena.GetComponent<BoxCollider2D>().bounds;
            minX = b.min.x;
            maxX = b.max.x;
            minY = b.min.y;
            maxY = b.max.y;

            Debug.Log($"Arena bounds set: X({minX},{maxX}) Y({minY},{maxY})");
        }
        else
        {
            Debug.LogWarning("There is a problem in finding Arena or in detecting box colider.");
        }

        StartCoroutine(TargetRoutine());
    }

    void Update()
    {
        // حرکت آزاد وقتی روی پلیر قفل نیست
        if (!isLockedOn)
        {
            MoveRandom();
        }

        // محدود کردن به محدوده آرنا
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    void MoveRandom()
    {
        if (moveDir == Vector2.zero)
        {
            int rand = Random.Range(0, 4);
            if (rand == 0) moveDir = Vector2.right;
            if (rand == 1) moveDir = Vector2.left;
            if (rand == 2) { moveDir = Vector2.up; anim.SetTrigger("jumpStart"); }
            if (rand == 3) { moveDir = Vector2.down; }

            currentSpeed = walkSpeed;
            if (rand <= 1)
                anim.SetTrigger("walkBody");

            StartCoroutine(ClearMoveDir(rand));
        }

        rb.linearVelocity = moveDir * currentSpeed;
    }

    IEnumerator ClearMoveDir(int rand)
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        rb.linearVelocity = Vector2.zero;
        moveDir = Vector2.zero;

        if (rand == 3) // وقتی حرکت به پایین بوده
        {
            anim.SetTrigger("jumpLand");
        }
        else
        {
            anim.SetTrigger("idle");
        }
    }

    IEnumerator TargetRoutine()
    {
        while (true)
        {
            // بین آرچر و سوردزمن سوئیچ کن
            if (currentTarget == archer)
                currentTarget = swordsman;
            else
                currentTarget = archer;

            isLockedOn = true;

            // حالت دفاع قبل از دویدن
            anim.SetTrigger("defence");
            yield return new WaitForSeconds(0.5f);

            currentSpeed = runSpeed;
            anim.SetTrigger("run");

            float lockTime = Random.Range(5f, 10f);
            float timer = 0f;

            while (timer < lockTime && currentTarget != null)
            {
                Vector2 dir = (currentTarget.transform.position - transform.position).normalized;
                rb.linearVelocity = dir * currentSpeed;

                // انیمیشن پرش وقتی بالا میره
                if (dir.y > 0.5f) anim.SetTrigger("jumpStart");
                // انیمیشن فرود وقتی پایین میاد
                if (dir.y < -0.5f) anim.SetTrigger("jumpLand");

                // پرتاب تار
                anim.SetTrigger("attack4");
                ShootWeb(dir);

                yield return new WaitForSeconds(2f);
                timer += 2f;
            }

            isLockedOn = false;
            rb.linearVelocity = Vector2.zero;
            anim.SetTrigger("idle");

            yield return null;
        }
    }

    void ShootWeb(Vector2 dir)
    {
        GameObject web = Instantiate(webPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D wrb = web.GetComponent<Rigidbody2D>();
        wrb.linearVelocity = dir * webSpeed;
    }
    public void BossDied()
    {
        rb.linearVelocity = Vector2.zero;
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayersDied()
    {
        rb.linearVelocity = Vector2.zero;
        losePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}