using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingSkyeSprite : MonoBehaviour
{
    private SpriteRenderer skye;
    [SerializeField] public SpriteRenderer otherSkye;
    [SerializeField] private float speed = 10;
    private Animator anim;

    [SerializeField] public Vector3 triggerLocation2;
    [SerializeField] public Vector3 triggerDirectionSection2;
    [SerializeField] public Vector3 triggerDirection2;
    private bool isTriggeredSection2;
    private bool isTriggered2;

    [SerializeField] public Vector3 triggerLocation3;
    [SerializeField] public Vector3 triggerDirectionSection3;
    [SerializeField] public Vector3 triggerDirection3;
    private bool isTriggeredSection3 = false;
    private bool isTriggered3 = false;

    private Vector3 previousPosition;

    private void Start()
    {
        anim = GetComponent<Animator>();
        skye = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if (isTriggeredSection2)
        {
            SkyeRunTo(triggerDirectionSection2);
            if (Vector2.Distance(transform.position, triggerDirectionSection2) < 0.1)
            {
                isTriggeredSection2 = false;
                isTriggered2 = true;
            }
        }

        if (isTriggered2)
        {
            SkyeRunTo(triggerDirection2);
            if (Vector2.Distance(transform.position, triggerDirection2) < 0.1)
            {
                isTriggered2 = false;
                anim.SetBool("isWalking", false);
                transform.position = triggerLocation2;
                skye.flipX = false;
            }
        }

        if (isTriggeredSection3)
        {
            SkyeRunTo(triggerDirectionSection3);
            if (Vector2.Distance(transform.position, triggerDirectionSection3) < 0.1)
            {
                isTriggeredSection3 = false;
                isTriggered3 = true;
            }
        }

        if (isTriggered3)
        {
            SkyeRunTo(triggerDirection3);
            if (Vector2.Distance(transform.position, triggerDirection3) < 0.1)
            {
                isTriggered3 = false;
                anim.SetBool("isWalking", false);
                skye.enabled = false;
                otherSkye.enabled = true;
            }
        }
    }

    public void MoveSkyeToTrigger2()
    {
        if (skye != null)
        {
            isTriggeredSection2 = true;
        }
    }

    public void MoveSkyeToTrigger3()
    {
        if (skye != null)
        {
            isTriggeredSection3 = true;
        }
    }

    private void SkyeRunTo(Vector3 target)
    {
        var movement = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.position = movement;
        anim.SetBool("isWalking", true);

        // direction stuff
        var currentPosition = transform.position;
        var delta = currentPosition - previousPosition;

        if (Mathf.Abs(delta.x) > 0)
        {
            skye.flipX = delta.x < 0;
        }

        previousPosition = currentPosition;
    }
}