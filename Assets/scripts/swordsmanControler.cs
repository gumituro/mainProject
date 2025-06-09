using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Collections;

public class SwordmanController : MonoBehaviour
{

    private float lastHorizontalDirection = 1f; //چپ1

    public AttackTrigger attackTrigger;

    // public Transform attackPoint;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    // public float attackRange = 0.5f;
    public int attackDamage = 1;
    public int baseDamage = 1;
    public bool isDead = false;


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


    public GameObject gameOverScreen;

    void Start()
    {
        if (anim == null) anim = GetComponent<Animator>();

        if (attackTrigger == null)
        {
            attackTrigger = GetComponentInChildren<AttackTrigger>();
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

        if (moveInput.x > 0.01f)
            lastHorizontalDirection = 1f;
        else if (moveInput.x < -0.01f)
            lastHorizontalDirection = -1f;

        sprite.flipX = lastHorizontalDirection < 0;




        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0f)
            {
                isDashing = false;
                rb.linearVelocity = Vector2.zero;
            }
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
            AudioManager.instance.PlaySFX(10);

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

        anim.SetTrigger("attack");
        AudioManager.instance.PlaySFX(1);



        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D Enemy in hitEnemies)
        {
            Debug.Log("hit enemy");

            Enemy.GetComponent<Enemy1Health>()?.TakeDamage(attackDamage);
            Enemy.GetComponent<Enemy2Health>()?.TakeDamage(attackDamage);
        }


    }



    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }






    // public void die()
    // {
    //     isDead = true; 
    //     anim.SetTrigger("dead");

    // }
    // public bool enemyInRange = false;
    // public GameObject currentEnemy = null;





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
    private bool isBoosted = false;

    public IEnumerator TemporaryDamageBoost(int boostAmount, float duration)
    {
        if (isBoosted) yield break;
        isBoosted = true;
        attackDamage += boostAmount;
        Debug.Log("Boosted damage: " + attackDamage);

        yield return new WaitForSeconds(duration);

        attackDamage = baseDamage;
        Debug.Log("Damage reset to: " + attackDamage);
        isBoosted = false;
    }




}
