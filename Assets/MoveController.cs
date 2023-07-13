using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpHigh;

    private Rigidbody2D rb;
    private float xInput;

    public float groundCheckRadius;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHigh);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere()
    }
}
