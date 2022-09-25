using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private float gravity;
    public GameObject groundCheck;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public float speed;

    private float defaultSpeed;

    public int jumpForce;
    public bool isGrounded;
    float moveDirection;
    bool isJumpPressed = false;

    bool isFacingLeft;

    private Vector3 velocity;
    public float smoothTime = 0.05f;



    [SerializeField] public bool canMove = true;
    [SerializeField] private float rotSpeed;

    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        defaultSpeed = speed;
        animator = gameObject.GetComponent<Animator>();
        animator.Play("Idle");

        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            moveDirection = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.Space) == true)
            {
                isJumpPressed = true;
            }

            if (moveDirection != 0)
            {
                animator.SetBool("Walking", true);
            }
            else
            {
                animator.SetBool("Walking", false);
            }

        }
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {

                isGrounded = true;
            }

        }



    }

    private void FixedUpdate()
    {






        float verticalVelocity = 0f;

        Vector3 calculatedMovement = Vector3.zero;


        if (isGrounded == false)
        {
            verticalVelocity = rb.velocity.y;

        }


        //  Animator.SetFloat("Speed", Mathf.Abs());

        calculatedMovement.x = speed * 100f * moveDirection * Time.fixedDeltaTime;

        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;
    }

    private void Move(Vector3 moveDirection, bool isJumpPressed)
    {
        if (moveDirection.x > 0f && isFacingLeft == true)
        {
            FlipSpriteDirection();
        }
        else if (moveDirection.x < 0f && isFacingLeft == false)
        {
            FlipSpriteDirection();
        }

        rb.velocity = Vector3.SmoothDamp(rb.velocity, moveDirection, ref velocity, smoothTime);




        if (isJumpPressed == true && isGrounded == true)
        {
            rb.AddForce(new Vector3(0f, jumpForce * 100f, 0f));
        }
    }


    private void FlipSpriteDirection()
    {
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public void GetSpeedBoost(float boost)
    {
        speed = boost;
        // speed *= boost;
    }
    public void returnToNormalSpeed()
    {
        speed = defaultSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, 0.2f);
    }


}
