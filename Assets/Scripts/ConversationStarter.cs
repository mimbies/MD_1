using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{

    [SerializeField] private NPCConversation myConvo;
    // Start is called before the first frame update
    public void Start()
    { ConversationManager.Instance.StartConversation(myConvo); }







}
