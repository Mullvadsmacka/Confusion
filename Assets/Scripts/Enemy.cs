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

    Rigidbody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = gameObject.transform.position;
        newPosition.x += direction * speed * Time.fixedDeltaTime;
        rigidBody2D.MovePosition(newPosition);
        GroundCheck();
        if (isGrounded == false)
        {
            ChangeDirection();
        }
    }
    private void GroundCheck()
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
}
