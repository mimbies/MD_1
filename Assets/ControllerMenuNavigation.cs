using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ControllerMenuNavigation : MonoBehaviour
{
    public Button[] menuButtons;
    private int selectedIndex = 0;

    private float lastInputTime = 0f;
    public float inputCooldown = 0.3f;
    private bool axisInUse = false;

    void Start()
    {
        // Initial Button auswählen
        
    }

    void Update()
    {



        if (Time.time - lastInputTime >= inputCooldown)
        {

            lastInputTime = Time.time;

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                lastInputTime = Time.time;
                selectedIndex = (selectedIndex - 1 + menuButtons.Length) % menuButtons.Length;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                lastInputTime = Time.time;
                selectedIndex = (selectedIndex + 1) % menuButtons.Length;
            }
            SelectButton(menuButtons[selectedIndex]);



            if (Input.GetButtonDown("Submit"))
            {
                menuButtons[selectedIndex].onClick.Invoke();
            }
        }
    }
        void SelectButton(Button button)
        {
            EventSystem.current.SetSelectedGameObject(button.gameObject);
        }

    }

