using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TestDiaActivator : MonoBehaviour
{
    public NPCConversation testConvo;
    public charaID thisChara;
    public bool inConversation; //sp�ter verhindern, dass Sprite �fters angeklickt werden kann.

    private void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0) && !inConversation)
        {            
            ConversationManager.Instance.StartConversation(DialogManager.diaManager.SetCurrentDialog(thisChara));
        }             
    }
}
