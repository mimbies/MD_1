using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SkyeManager : MonoBehaviour
{
    public bool isWalking;
    
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private float speed = 4;
    [SerializeField] private Transform target;
    [SerializeField] public bool followActive = false;
    private Vector3 previousPosition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (followActive)
        {
            FollowPlayer();
        }
    }

    private void LateUpdate()
    {
        if (transform.position.y < target.position.y)
        {
            sprite.sortingOrder = target.GetComponent<SpriteRenderer>().sortingOrder + 1;
        } else
        {
            sprite.sortingOrder = target.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }

    public void EnableFollow()
    {
        followActive = true;
    }

    private void FollowPlayer()
    {
        var distance = Vector2.Distance(transform.position, target.position);
        var movement = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (distance > 1)
        {
            transform.position = movement;
            anim.SetBool("isWalking", true);
        }
        else
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
