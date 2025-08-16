using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Archer3Controller : MonoBehaviour
{

    public int baseDamage = 1;
    public int attackDamage = 1;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded = true;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction attackAction;

    public Animator anim;
    public SpriteRenderer sprite;

    [Header("Arrow Settings")]
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float arrowSpeed = 10f;

    private bool canShoot = true;
    public float shootCooldown = 0.5f;

    void Start()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

        attackDamage = baseDamage;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("Archer");


        moveAction = playerInput.actions["move"];

        attackAction = playerInput.actions["attack"];

        attackAction.performed += ctx => Attack();
    }

    private void OnEnable()
    {
        moveAction.Enable();

        attackAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();

        attackAction.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0)
            sprite.flipX = true;
        else if (moveInput.x > 0)
            sprite.flipX = false;

       anim.SetFloat("moveSpeed", moveInput.magnitude);





    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x, moveInput.y);
        rb.linearVelocity = movement * moveSpeed;
    }




    private void Attack()
    {
        if (!canShoot) return;

        anim.SetTrigger("attack");

        canShoot = false;
        Invoke(nameof(ResetShoot), shootCooldown);
        Invoke(nameof(ShootArrow), 0.8f); // Delay before shooting arrow

    }

//     private void Attack()
// {
//     if (!canShoot) return;

//     anim.SetTrigger("attack");

//     ShootArrow(); // تیر مستقیم ایجاد شود

//     canShoot = false;
//     Invoke(nameof(ResetShoot), shootCooldown);
// }



    private void ResetShoot()
    {
        canShoot = true;
    }

    private void ShootArrow()
    {
            Debug.Log("Shooting Arrow!");

        // AudioManager.instance.PlaySFX(0);

        float direction = sprite.flipX ? -1f : 1f;

        Vector3 spawnPosition = shootPoint.position;
        spawnPosition.x += direction * 0.2f;


        GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        if (arrowRb != null)
        {
            arrowRb.linearVelocity = new Vector2(direction * arrowSpeed, 0f);
        }

        SpriteRenderer arrowSprite = arrow.GetComponent<SpriteRenderer>();
        if (arrowSprite != null)
        {
            arrowSprite.flipX = direction < 0;
        }
    }

    // private bool isBoosted = false;

    // public IEnumerator TemporaryDamageBoost(int boostAmount, float duration)
    // {
    //     if (isBoosted) yield break; 
    //     isBoosted = true ;
    //     attackDamage += boostAmount;
    //     Debug.Log("Boosted damage: " + attackDamage);

    //     yield return new WaitForSeconds(duration);

    //     attackDamage = baseDamage;
    //     Debug.Log("Damage reset to: " + attackDamage);
    //     isBoosted = false; 
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     isGrounded = true;
        // }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Ground"))
        // {
        //     isGrounded = false;
        // }
    }

    public void TakeDamage()
    {
        anim.SetTrigger("hurt");
        Debug.Log("Character took damage!");
    }


}
