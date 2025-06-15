using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManger : MonoBehaviour
{
    public List<ButtonPuzzle> buttons;
    public List<int> correctOrder;
    private List<int> currentInput = new List<int>();
    private int startIndex = 0;

    public void ButtonPressed(int id)
    {
        if (currentInput.Count == 0)
        {
            startIndex = correctOrder.IndexOf(id);
            ///-----------------------h‰‰‰‰‰‰‰‰ digga? 
            if (startIndex == -1)
            {
                Debug.Log("Ung¸ltiger Startknopf!");
                ResetButtons();
                return;
            }

            currentInput.Add(id);
            return;
        }

        int expectedIndex = (startIndex + currentInput.Count) % correctOrder.Count;
        int expectedID = correctOrder[expectedIndex];


        if (id != expectedID)
        {
            Debug.Log("Falsche Reihenfolge! Reset.");
            ResetButtons();
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
            Debug.Log("Puzzle gelˆst!");

            foreach (var button in buttons)
            {
                button.SetColor(Color.green);
            }

        }


    }
    public void ResetButtons()
    {
        currentInput.Clear();
        startIndex = 0;
        foreach (ButtonPuzzle button in buttons)
        {
            button.ResetButton();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
