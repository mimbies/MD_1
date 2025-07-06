using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SkyeManager : MonoBehaviour
{
    public int direction;
    public bool isWalking;
    public Rigidbody2D rb;
    
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        var distance = Vector2.Distance(transform.position, target.position);
        var movement = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (distance > 1)
        {
            transform.position = movement;
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }

        // direction stuff
        var currentPosition = transform.position;
        var delta = currentPosition - previousPosition;

        if (Mathf.Abs(delta.x) > 0)
        {
            sprite.flipX = delta.x < 0;
        }

        previousPosition = currentPosition;
    }

}
