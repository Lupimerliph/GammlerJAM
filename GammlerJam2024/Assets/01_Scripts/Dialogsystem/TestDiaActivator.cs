using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class TestDiaActivator : MonoBehaviour
{
    public NPCConversation testConvo;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(testConvo);
        }             
    }
}
