using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private Animator animator;
    public float speed = 5;
    private float direction = 1f;
    public GameObject groundCheck;
    private bool isGrounded;
    public Transform groundDetector;
    public Transform wallDetector;
    public LayerMask groundLayer;

    Rigidbody2D rigidBody2D;
   [SerializeField] public float groundDetectionRange;
    public float wallDetectionRange;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        EdgeChecker();
        WallChecker();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.x += direction * speed * Time.fixedDeltaTime;
        rigidBody2D.MovePosition(newPosition);
       
        if (isGrounded == false)
        {
           // ChangeDirection();
        }
    }


    void EdgeChecker()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetector.position, Vector2.down, groundDetectionRange);
        if (groundInfo.collider == false || groundInfo.collider.CompareTag("Enemy") == true)
        {
            ChangeDirection();
        }
    }

    void WallChecker()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(wallDetector.position, wallDetector.transform.TransformDirection(wallDetector.right), wallDetectionRange, groundLayer);
        if (groundInfo.collider == true)
        {
            ChangeDirection();
        }
    }


    /*private void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;

            }
        }
    }

    */
    public void ChangeDirection()
    {
        direction = -direction;
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x = direction;
        gameObject.transform.localScale = currentScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            ChangeDirection();
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(groundDetector.position, Vector2.down * groundDetectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallDetector.position, wallDetector.transform.TransformDirection(wallDetector.right) * wallDetectionRange);
    }
}
