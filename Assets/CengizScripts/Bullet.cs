using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour


{

    public GameObject hitEffect;
    public Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision2)
    {
        if (collision2.gameObject.TryGetComponent<Karlo>(out Karlo enemyComponent))
        {
            enemyComponent.TakeDamage(1);
        }
        Destroy(gameObject);
        Destroy(Instantiate(hitEffect, transform.position, transform.rotation),.2f);


    }
    //void OnTriggerEnter2D (Collider2D collision)
    //{

        //Karlo gegner = collision.GetComponent<Karlo>();
        //if (gegner != null)
        //{
        //    gegner.TakeDamage(1);
        //}
        //Destroy(gameObject);
        //Instantiate(hitEffect, transform.position, transform.rotation);
       

       // if (collision.gameObject.TryGetComponent(out karlo enemycomponent))
       // {
       //     enemycomponent.takeDamage(1);
       //     Destroy(gameObject);
       //     Destroy(hitEffect);
       // }


       // if (collision.gameObject.tag.Equals("karl"))
       // {
       //     Destroy(gameObject);
            
       //     Destroy(collision.gameObject);

       // }
       // Destroy(gameObject);
        
       

    //}
    //private void Update()
    //{
    //    Destroy(gameObject, 10f);
    //}
}
