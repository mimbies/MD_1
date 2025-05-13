using System.Collections;
using System.Collections.Generic;
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
        


        //movement
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");
        movement = new Vector2(movex, movey).normalized;


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



        //animation
        if(movement.magnitude != 0)
        {
            GetComponent<SpriteRenderer>().flipX = movex < 0;
        }

        anim.SetBool("isWalking", movement.magnitude > 0);
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



}
