using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonManger : MonoBehaviour
{
    public List<ButtonPuzzle> buttons;
    public List<int> correctOrder;
    private List<int> currentInput = new List<int>();
    private int startIndex = 0;

    public List<GameObject> lights;
    public List<Light2D> spotlights;

    private Color lightOriginalColor;

    public GameObject objToSetActive;

    void Start()
    {
        lightOriginalColor = lights[0].GetComponent<SpriteRenderer>().color;

        foreach (GameObject light in lights)
        {
            Light2D childLight = light.GetComponentInChildren<Light2D>();
            spotlights.Add(childLight);
        }
        foreach (Light2D light in spotlights)
        {
            light.enabled = false;
        }



    }

    public void ButtonPressed(int id)
    {
        if (currentInput.Count == 0)
        {
            startIndex = correctOrder.IndexOf(id);
            ///-----------------------h�������� digga? 
            if (startIndex == -1)
            {
                Debug.Log("Ung�ltiger Startknopf!");
                ResetButtons(id);
                return;
            }

            currentInput.Add(id);
            spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().enabled = true;
            spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().color = new Color(1f, 0.243f, 0f);
            lights[correctOrder.IndexOf(id)].GetComponent<SpriteRenderer>().color = Color.yellow;


            return;
        }

        lights[correctOrder.IndexOf(id)].GetComponent<SpriteRenderer>().color = Color.yellow;

        spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().enabled = true;
        spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().color = new Color(1f, 0.243f, 0f);



        int expectedIndex = (startIndex + currentInput.Count) % correctOrder.Count;
        int expectedID = correctOrder[expectedIndex];


        if (id != expectedID)
        {
            Debug.Log("Falsche Reihenfolge! Reset.");
            ResetButtons(id);
            return;
        }

        currentInput.Add(id);


        //for (int i = 0; i < currentInput.Count; i++)
        //{
        //    if (currentInput[i] != correctOrder[i])
        //    {

        //        ResetButtons();
        //        return;
        //    }
        //}
        ////----------------------------------------------------------------

        if (currentInput.Count == correctOrder.Count)
        {
            Debug.Log("Puzzle gel�st!");

            foreach (var button in buttons)
            {
                button.SetColor(Color.green);
            }

            StartCoroutine(FlashGreen());


        }


    }
    private IEnumerator FlashGreen()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (Light2D light in spotlights)
            {
                light.enabled = false;
            }
            yield return new WaitForSeconds(0.3f);

            foreach (Light2D light in spotlights)
            {
                light.enabled = true;
                light.color = Color.green;
            }
            yield return new WaitForSeconds(0.3f);

            foreach (Light2D light in spotlights)
            {
                light.color = new Color(1f, 0.243f, 0f);
            }
            yield return new WaitForSeconds(0.3f);
        }


        objToSetActive.SetActive(true);






    }

    public void ResetButtons(int id)
    {
        currentInput.Clear();
        startIndex = 0;
        StartCoroutine(FlashRedThenReset(id));

    }

    private IEnumerator FlashRedThenReset(int id)
    {
        lights[correctOrder.IndexOf(id)].GetComponent<SpriteRenderer>().color = Color.red;

        spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().enabled = true;
        spotlights[correctOrder.IndexOf(id)].GetComponent<Light2D>().color = Color.red;
        yield return new WaitForSeconds(1f);


        foreach (Light2D light in spotlights)
        {
            light.enabled = false;
        }


        foreach (GameObject light in lights)
        {
            light.GetComponent<SpriteRenderer>().color = lightOriginalColor;


        }

        foreach (ButtonPuzzle button in buttons)
        {
            button.ResetButton();
        }
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
