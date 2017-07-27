using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0F;

    private Vector2 moveDirection;
    private Rigidbody2D rb2d;
    private bool canWalk;

    // Use this for initialization
    void Start()
    {
        canWalk = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Use input up and down for direction, multiplied by speed
        if (canWalk)
        {
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveDirection *= speed;
            // Move Character Controller
            rb2d.velocity = moveDirection;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            rb2d.velocity = Vector2.zero;
        }
        if (other.gameObject.tag == "Car")
        {
            Debug.Log("hey");
            rb2d.velocity = Vector2.zero;
        }
        Debug.Log("hey");
    }
}