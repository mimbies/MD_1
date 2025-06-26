using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SkyeManager : MonoBehaviour
{
    public float moveSpeed;
    public int direction;
    public bool isWalking;
    private Vector2 velocity;
    private float horizontal;
    private float vertical;
    private float inputPower;

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        inputPower = new Vector2(horizontal, vertical).magnitude;

        if(inputPower != 0)
        {
            GetComponent<SpriteRenderer>().flipX = (horizontal < 0);
        }

        velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

        anim.SetBool("isWalking", (inputPower > 0));
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
