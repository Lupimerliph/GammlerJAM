using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DiaActivator : MonoBehaviour
{
    public charaID thisChara;
    
    private void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0) && !DialogManager.diaManager.inConversation)
        {            
            ConversationManager.Instance.StartConversation(DialogManager.diaManager.SetCurrentDialog(thisChara));
        }             
    }
}
