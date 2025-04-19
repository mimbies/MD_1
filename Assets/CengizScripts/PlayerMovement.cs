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
    bool pause;

    //sound
    [SerializeField] private AudioSource aua1;
    [SerializeField] private AudioSource aua2;


    //FLasher

    [SerializeField] private Material flashMaterial;

    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;


    //kamera
    public Camera cam;
    Vector2 mousePos;
    public float fov;

    //leben
    [SerializeField] float healt, maxhealth = 3f;

    //animation 
    private Animator anim;





    public void Awake()
    {
        cam.fieldOfView = fov;
    }
    private void Start()
    {
        //flasher 
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;

        anim = GetComponent<Animator>();
        healt = maxhealth;
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





    }


    void FixedUpdate()

    {
        Physics2D.IgnoreLayerCollision(2, 4);
        //animation x achse Normal

    



        inputVector = Vector2.SmoothDamp(inputVector, movement, ref inputVelo, smoothspeed);
        rb.velocity = new Vector2(inputVector.x * moveSpeed, inputVector.y* moveSpeed);

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
            Flash();
        }

    }
    public void takeDamage(float schaden)
    {
        healt -= schaden;
        Flash();
        aua1.Play();
        aua2.Play();



        if (healt <= 0)
        {
            //ScoreScript.scoreValue = 0;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

          
        }
    }
    public void Flash()
    {

        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }
}
