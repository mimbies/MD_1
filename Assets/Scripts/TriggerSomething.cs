using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TriggerSomething : MonoBehaviour
{

    [SerializeField] private NPCConversation myConvo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Trigger");
            ConversationManager.Instance.StartConversation(myConvo);
        }

    }
}
