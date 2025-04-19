using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radnokarls : MonoBehaviour
{
    public GameObject Karl;
    public int xpos;
    public int ypos;
    public int karlsfamilie;
    void Start()
    {
        StartCoroutine(KarlsMutter());
    }

    IEnumerator KarlsMutter()
    {
        while (karlsfamilie < 20)
        {
            xpos = Random.Range(-20, 20);
            ypos = Random.Range(-10, 20);
            Instantiate(Karl, new Vector2(xpos, ypos), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
  
    }

}
