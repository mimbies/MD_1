using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TriggerSomething : MonoBehaviour
{

    [SerializeField] private NPCConversation myConvo;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to
    /// this object (2D physics only).
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered Trigger Zone");
            ConversationManager.Instance.StartConversation(myConvo);
        }

    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && this.gameObject.tag != "Tip")
        {
            Debug.Log("Left Trigger Zone");
            Destroy(this.gameObject);
        }

    }
}
