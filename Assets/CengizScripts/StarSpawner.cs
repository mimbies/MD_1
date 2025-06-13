using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star;
    [SerializeField] float flyingTime = 5f;
    


    // Start is called before the first frame update
    void Start()
    {


        //vector erzeugen 
        Vector2 vector = MakeVector();

        //Startpunkt finden 
        Vector2 startPoint = getStartingPoint(vector); 

        //stern erzeugen 
        GameObject starGameObject =  Instantiate(star, startPoint, Quaternion.identity);

        //sternbewegen test 
        Rigidbody2D rbFromStar = starGameObject.GetComponent<Rigidbody2D>();
        float flyingSpeed = 0.25f;
        rbFromStar.velocity = vector * flyingSpeed;

        //sehr assozial gecoded / bruteforced
        Collider2D col = starGameObject.GetComponent<Collider2D>();
        StartCoroutine(EnableColliderAfterDelay(3.5f, col));
        Destroy(starGameObject, 4f);
        



        //stern bewegen klappt aber unschön 
        //StartCoroutine(MoveAlongVector(starGameObject.transform, vector, flyingTime));





    }

    //sehr assozial 
    IEnumerator EnableColliderAfterDelay(float delay, Collider2D col)
    {
        yield return new WaitForSeconds(delay);
        col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    IEnumerator MoveAlongVector(Transform starTransform, Vector2 vector, float duration)
    {
        //fluglinie 
        Vector2 startPosition = starTransform.position;
        Vector2 endPosition = startPosition + vector;

        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            starTransform.position = Vector2.Lerp(startPosition, endPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        starTransform.position = endPosition;


    }

    Vector2 MakeVector()
    {
        float angle = Random.Range(180f, 360f);  //winkelbereich
        float rad = angle * Mathf.Deg2Rad; //umwandlung in bogenmaß 

        Vector2 vec = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;

        return vec * 10f;


    }

    Vector2 getStartingPoint(Vector2 vector)
    {
        //ZielRechteck (map Größe) 
        Vector2 buttomLeft = new Vector2(-8f,-4f); 
        Vector2 topRight = new Vector2(8f,3f);

        Vector2 vectorEnd = new Vector2(Random.Range(buttomLeft.x,topRight.x), Random.Range(buttomLeft.y,topRight.y));

        Vector2 vectorStart = vectorEnd - vector;

        //malen zum debuggen
        Debug.DrawLine(vectorStart, vectorEnd, Color.red, 10f);

        return vectorStart; 


    }
}
