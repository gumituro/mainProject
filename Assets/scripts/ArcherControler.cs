using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 

public class ArcherController : MonoBehaviour
{

    public int baseDamage = 1;
    public int attackDamage= 1; 

    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float doubleJumpForce = 8f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded = true;
    private bool canDoubleJump = false;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction doubleJumpAction;
    private InputAction attackAction;
    private InputAction downDashAction;

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

        moveAction = playerInput.actions["move"];
        jumpAction = playerInput.actions["jump"];
        doubleJumpAction = playerInput.actions["doubleJump"];
        attackAction = playerInput.actions["attack"];
        downDashAction = playerInput.actions["downDash"];

        jumpAction.performed += ctx => Jump();
        doubleJumpAction.performed += ctx => DoubleJump();
        attackAction.performed += ctx => Attack();
        downDashAction.performed += ctx => DashDown();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        doubleJumpAction.Enable();
        attackAction.Enable();
        downDashAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        doubleJumpAction.Disable();
        attackAction.Disable();
        downDashAction.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0)
            sprite.flipX = true;
        else if (moveInput.x > 0)
            sprite.flipX = false;


        // // Flip sprite based on movement or velocity
        // if (rb.velocity.x < 0)
        //     sprite.flipX = true;
        // else if (rb.velocity.x > 0)
        //     sprite.flipX = false;

        // Animation states
        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(rb.linearVelocity.x));

        // Enable double jump if grounded
        if (isGrounded)
        {
            canDoubleJump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                            AudioManager.instance.PlaySFX(10);

            isGrounded = false;
            canDoubleJump = true;
        }
    }

    private void DoubleJump()
    {
        if (canDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, doubleJumpForce);
                            AudioManager.instance.PlaySFX(10);

            canDoubleJump = false;
        }

        Debug.Log("Double jump key pressed");
    }

    private void Attack()
    {
        if (!canShoot) return;

        anim.SetTrigger("attack");
                        AudioManager.instance.PlaySFX(0);

        canShoot = false;
        Invoke(nameof(ResetShoot), shootCooldown);
        Invoke(nameof(ShootArrow), 0.8f); // Delay before shooting arrow
    }
    
    private void DashDown() {
        // if (!isGrounded)
        //     rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce * 1.5f);
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce);
            isGrounded = false;
        }
        Debug.Log("DashDown key pressed");
    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void ShootArrow()
    {
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

    private bool isBoosted = false;

    public IEnumerator TemporaryDamageBoost(int boostAmount, float duration)
    {
        if (isBoosted) yield break; 
        isBoosted = true ;
        attackDamage += boostAmount;
        Debug.Log("Boosted damage: " + attackDamage);

        yield return new WaitForSeconds(duration);

        attackDamage = baseDamage;
        Debug.Log("Damage reset to: " + attackDamage);
        isBoosted = false; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage()
    {
        anim.SetTrigger("hurt");
        Debug.Log("Character took damage!");
    }


}
