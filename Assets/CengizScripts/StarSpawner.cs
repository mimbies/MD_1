using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star;
    public GameObject shadow;
    [SerializeField] float flyingTime = 5f;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStarsRoutine());


    }

    IEnumerator SpawnStarsRoutine()
    {
        while (true)
        {
            SpawnStarAndShadow();
            yield return new WaitForSeconds(1f);
        }
    }

    void SpawnStarAndShadow()
    {
        //vector erzeugen 
        Vector2 vector = MakeVector();
        Vector2 oppositeVector = -vector;
        //optimierungsbedarf
        float angle = Mathf.Atan2(oppositeVector.y, oppositeVector.x) * Mathf.Rad2Deg;



        //Startpunkt finden 
        Vector2 startPoint = getStartingPoint(vector);


        //schatten erstellen
        Vector2 endPoint = startPoint + vector;
        GameObject shadowGameObject = Instantiate(shadow, endPoint, Quaternion.identity);



        //stern erzeugen 
        GameObject starGameObject = Instantiate(star, startPoint, Quaternion.identity);

        Star starController = starGameObject.GetComponent<Star>();

        starController.SetShadow(shadowGameObject);








        //partikel drehen
        ParticleSystem glitter = starGameObject.GetComponentInChildren<ParticleSystem>();
        if (glitter != null)
        {
            glitter.transform.rotation = Quaternion.Euler(0, 0, angle);
        }



        //sternbewegen test 
        Rigidbody2D rbFromStar = starGameObject.GetComponent<Rigidbody2D>();
        float flyingSpeed = 0.25f;
        rbFromStar.velocity = vector * flyingSpeed;

        //sehr assozial gecoded / bruteforced
        Collider2D col = starGameObject.GetComponent<Collider2D>();
        col.enabled = false;
        StartCoroutine(EnableColliderAfterDelay(3.7f, col));
        StartCoroutine(AnimateShadow(shadowGameObject, 3.5f));
        Destroy(starGameObject, 4f);
        Destroy(shadowGameObject, 4f);


        //stern bewegen klappt aber unsch�n 
        //StartCoroutine(MoveAlongVector(starGameObject.transform, vector, flyingTime));

    }

    IEnumerator AnimateShadow(GameObject shadow, float duration)
    {
        SpriteRenderer shadowSprite = shadow.GetComponent<SpriteRenderer>();
        Transform shadowTransform = shadow.transform;

        float timeElapsed = 0f;

        Vector2 startScale = Vector2.zero;
        Vector2 endScale = Vector2.one;

        Color startColor = new Color(0, 0, 0, 0);
        Color endColor = new Color(0, 0, 0, 0.75f);


        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            shadowTransform.localScale = Vector3.Lerp(startScale, endScale, t);
            shadowSprite.color = Color.Lerp(startColor, endColor, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }



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
        float rad = angle * Mathf.Deg2Rad; //umwandlung in bogenma� 

        Vector2 vec = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;

        return vec * 10f;


    }

    Vector2 getStartingPoint(Vector2 vector)
    {
        //ZielRechteck (map Gr��e) 
        Vector2 buttomLeft = new Vector2(-8f, -4f);
        Vector2 topRight = new Vector2(8f, 3f);

        Vector2 vectorEnd = new Vector2(Random.Range(buttomLeft.x, topRight.x), Random.Range(buttomLeft.y, topRight.y));

        Vector2 vectorStart = vectorEnd - vector;

        //malen zum debuggen
        Debug.DrawLine(vectorStart, vectorEnd, Color.red, 10f);

        return vectorStart;


    }


}
