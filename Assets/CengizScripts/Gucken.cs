using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gucken : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public SpriteRenderer a;
   
   
    Vector2 mousePos;


    // Update is called once per frame
    void Update()
    {
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //kamera

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if(angle > 90 || angle < -90)
        {
            a.flipY = true;
        }
        else
        {
            a.flipY = false;
        }
        if(angle > 0 || angle < -180)
        {
            //layer.diese = 10;
        }
        else
        {
            //layer.diese = 11;
        }



        

    }
}
