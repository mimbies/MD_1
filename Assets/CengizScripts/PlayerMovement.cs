using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //movement
    public float moveSpeed;
    public Rigidbody2D rb;
    public float smoothspeed;
    Vector2 movement;
    Vector2 inputVector;
    Vector2 inputVelo;
    float lastMoveX;

    //partikel 
    public GameObject dustEffectPrefab;
    private bool canSpawnDust = true;


    //sound



    //FLasher



    //kamera
    public Camera cam;
    Vector2 mousePos;
    public float fov;

    //leben
    [SerializeField] float healt, maxhealth = 3f;

    //animation
    public bool isWalking;
    private Animator anim;



    //partikel-----------------------------------------------------------------------------
    void CreateDust()
    {
        Vector3 dustPosition = new Vector3(transform.position.x, transform.position.y - 0.46f, transform.position.z);
        GameObject dust = Instantiate(dustEffectPrefab, dustPosition, Quaternion.identity);
        Destroy(dust, 1f);
    }
    void ResetDustCooldown()
    {
        canSpawnDust = true;
    }
    //----------------------------------------------------------------------------------------


    public void Awake()
    {
        cam.fieldOfView = fov;
    }
    private void Start()
    {

        healt = maxhealth;

        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isWalking", movement.magnitude > 0);

        if (ConversationManager.Instance != null && ConversationManager.Instance.IsConversationActive)
        {
            movement = Vector2.zero;
            if (isWalking)
            {
                anim.Play("idle");
            }
            return;
        }

        //movement
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        movement = new Vector2(movex, movey).normalized;

        if (movex != 0)
        {
            lastMoveX = movex;
        }

        //animation
        if (movement.magnitude != 0)
        {
            GetComponent<SpriteRenderer>().flipX = lastMoveX < 0;

            //partikel--------------------------------------------------
            if (canSpawnDust)
            {
                CreateDust();
                canSpawnDust = false;
                Invoke(nameof(ResetDustCooldown), 0.1f);
            }
            //----------------------------------------------------------
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //if (input.getbuttondown(keycode.space))
        //{
        //    if (!pause)
        //    {
        //        time.timescale = 0;
        //        pause = true;
        //    }
        //    else
        //    {
        //        time.timescale = 1;
        //        pause = false;
        //    }
        //}
    }


    void FixedUpdate()

    {
        Physics2D.IgnoreLayerCollision(2, 4);
        //animation x achse Normal





        inputVector = Vector2.SmoothDamp(inputVector, movement, ref inputVelo, smoothspeed);
        rb.velocity = new Vector2(inputVector.x * moveSpeed, inputVector.y * moveSpeed);

        //kamera
        //Vector2 lookDir = mousePos - rb.position;
        //float angle= Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
        //rb.rotation = angle;
    }



    public void FlipEnola()
    {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }







    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement enemyComponent))
        {
            enemyComponent.takeDamage(1);

        }



    }


    public void takeDamage(float schaden)
    {





    }

    public void increaseMovementSpeed()
    {

        moveSpeed = 5f;

    }



}
