using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TestDiaActivator : MonoBehaviour
{
    public NPCConversation testConvo;
    public charaID thisChara; 

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            ConversationManager.Instance.StartConversation(DialogManager.diaManager.SetCurrentDialog(thisChara));
        }             
    }
}
