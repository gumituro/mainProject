using UnityEngine;
using UnityEngine.InputSystem;

public class SwordmanController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashForce = 15f;
    public float dashDuration = 0.2f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded = true;
    private bool isDashing = false;

    private float dashTime;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction dashAction;

    public Animator anim;
    public SpriteRenderer sprite;

    void Start()
    {
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        moveAction = playerInput.actions["move"];
        jumpAction = playerInput.actions["jump"];
        attackAction = playerInput.actions["attack"];
        dashAction = playerInput.actions["dash"];

        jumpAction.performed += ctx => Jump();
        attackAction.performed += ctx => attack();
        dashAction.performed += ctx => Dash();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        attackAction.Enable();
        dashAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
        attackAction.Disable();
        dashAction.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                isDashing = false;
                rb.linearVelocity = Vector2.zero;
            }
        }
        if (rb.linearVelocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if (rb.linearVelocity.x > 0)
        {
            sprite.flipX = false;
        }

        anim.SetBool("isJumping", !isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(rb.linearVelocity.x));

    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        }
    }

    private void Jump()
    {
        if (isGrounded && !isDashing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            dashTime = dashDuration;

            Vector2 dashDirection = new Vector2(moveInput.x, 0f).normalized;
            if (dashDirection == Vector2.zero) dashDirection = Vector2.right;

            rb.linearVelocity = dashDirection * dashForce;
        }
    }

    private void attack()
    {
        if (!isDashing && isGrounded)
        {
            anim.SetTrigger("attack");
            Debug.Log("Attack Triggered");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
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
        //این قسمت برای کاهش جون
        Debug.Log("Character took damage!");
    }

//تست برای تیک دمچ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyAttack"))
        {
            TakeDamage();
        }
    }
}
