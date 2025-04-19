using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karlo : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float healt; 
    public float maxHealth = 3f;
    public float trigger=1f;

    //weiss wenn die bullets treffen. 
    [SerializeField] private Material flashMaterial;

    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;


    //sound
    [SerializeField] private AudioSource baam;
    [SerializeField] private AudioSource baam2;










    private Animator anim;
    void Start()
    {
        healt = maxHealth;
        rb = this.GetComponent<Rigidbody2D>();
        
        //flasher 
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GameObject.FindGameObjectWithTag("player").transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle - 90f;
        direction.Normalize();
       
        movement = direction;
        if (Random.Range(0, 5) % 2 == 0)
        {
            baam2.Play();
        }



    }
    private void FixedUpdate()
    {
        MoveCharacter(movement);

        //MoveCharacter(movement);
    }
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        
        if (direction.x > 0)
        {
            anim.SetBool("rechts", true);
        }

        if (direction.x < 0)
        {
            anim.SetBool("links", true);
        }
        //ende animation normal
        if (direction.x == 0)
        {
            anim.SetBool("rechts", false);
            anim.SetBool("links", false);
        }

        //animation y achse Normal
        if (direction.y > 0)
        {

            anim.SetBool("oben", true);
        }
        if (direction.y < 0)
        {
            anim.SetBool("unten", true);
        }
        //ende animation normal
        if (direction.y == 0)
        {
            anim.SetBool("oben", false);
            anim.SetBool("unten", false);
        }

    }

    public void TakeDamage(int schaden)
    {
        Flash();
        baam.Play();
        healt -= schaden;
        
        

        if (healt <= 0)
        {
            
            //int xpos = Random.Range(3, 8);
            //int ypos = Random.Range(8, 12);
            //Instantiate(gameObject, new Vector2(xpos, ypos), Quaternion.identity);
            //xpos = Random.Range(3, 8);
            //ypos = Random.Range(8, 12);
            //Instantiate(gameObject, new Vector2(xpos, ypos), Quaternion.identity);
            
            ScoreScript.scoreValue += 10;
            
            Flash();
            Destroy(gameObject);



        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement enemyComponent))
        {
            
            enemyComponent.takeDamage(1f);
            Destroy(gameObject);



        }

    }
    public void Flash()
    {
        
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        baam.Play();
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
