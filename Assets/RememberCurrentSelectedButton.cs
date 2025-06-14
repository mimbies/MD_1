using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RememberCurrentSelectedButton : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject selectedButton;


    private void Reset()
    {
        eventSystem = FindObjectOfType<EventSystem>();

        if (!eventSystem)
        {
            Debug.Log("oh oh kein Event system in der Scene Naugthy naughty", this);
            return;
        }

        selectedButton = eventSystem.firstSelectedGameObject;

    }

    // Update is called once per frame
    void Update()

    {
        if (!eventSystem) return;

        if(eventSystem.currentSelectedGameObject && selectedButton != eventSystem.currentSelectedGameObject)
        {
            selectedButton = eventSystem.currentSelectedGameObject; 
        }

        if(!eventSystem.currentSelectedGameObject && selectedButton)
        {
            eventSystem.SetSelectedGameObject(selectedButton);
        }


    }
}
