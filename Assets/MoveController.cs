using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHigh;

    private Rigidbody2D rb;
    private Transform groundCheck;

    private float xInput;

    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;

    [SerializeField] private LayerMask whatIsGround;

    private bool isGrounded;

    private void Awake()
    {
        groundCheck = transform.GetChild(0).gameObject.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log(whatIsGround.value);
        Debug.Log(groundCheckRadius);
        Debug.Log(groundCheck.position);
    }

    // Update is called once per frame
    void Update()
    {
        CollisionChecks();

        xInput = Input.GetAxisRaw("Horizontal");
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround.value);
    }

    private void Jump()
    {
        if(isGrounded == true) rb.velocity = new Vector2(rb.velocity.x, jumpHigh);
    }

    private void Movement()
    {
        if (isGrounded== true) rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
        else
        {
            if (xInput != 0)
            {
                rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
            }
        }
    }

    private void OnDrawGizmos()
    {
        groundCheck = transform.GetChild(0).gameObject.transform;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
