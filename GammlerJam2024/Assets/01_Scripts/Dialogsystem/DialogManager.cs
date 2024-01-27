using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogManager : MonoBehaviour
{
    public static DialogManager diaManager;
    public charaID currentChara;
    public bool inConversation; //später verhindern, dass Sprite öfters angeklickt werden kann.
    public NPCConversation currentDialog;
    public NPCConversation testDia, milDia, enDia, pebDia, bearDia, friDia, pabloDia, mcDia;  
    public DiaActivator currentSpeaker;

    private void Awake()
    {
        if (diaManager == null)
        {
            diaManager = this;
        }
    }

    public NPCConversation SetCurrentDialog(charaID chara)
    {
        currentChara = chara;
        //später muss hier currentDialog gesetzt werden durch CHara
            switch (currentChara)
        {
            case charaID.mc:
                currentDialog = InsertConversation(1, mcDia);
                break;
            case charaID.millie:                
                currentDialog = InsertConversation(2, milDia);
                break;
            case charaID.enrico:
                currentDialog = InsertConversation(3, enDia);
                break;
            case charaID.pebbles:
                currentDialog = InsertConversation(4, pebDia);
                break;
            case charaID.bearnand:
                currentDialog = InsertConversation(5, bearDia);
                break;
            case charaID.fritz:
                currentDialog = InsertConversation(6, friDia);
                break;
            case charaID.pablo:
                currentDialog = InsertConversation(7, pabloDia);
                break;           
            case charaID.testChara:
                currentDialog = InsertConversation(8, testDia); 
                break;
    }

        NPCConversation convo = currentDialog;
        inConversation = true;
        return convo;

    } 

    public NPCConversation InsertConversation(int index, NPCConversation charaConvo)
    {
        if (charaConvo == null)
        {
            return GameManager.gmManager.SetNewConvo(index).GetComponent<NPCConversation>();
        }
        else return charaConvo;
    }
    private void OnEnable()
    {
        ConversationManager.OnConversationEnded += EndConversation;
    }
    private void OnDisable()
    {
        ConversationManager.OnConversationEnded -= EndConversation;
    }

    public void EndConversation()
    {
        currentSpeaker.MoveCharacter(currentSpeaker.originPosition, currentSpeaker.originScale);
        inConversation = false;
        Debug.Log("ThisConversation is over");
    }
}

public enum charaID
{
    mc,
    millie,
    enrico, 
    pebbles,
    bearnand,
    fritz,
    pablo,
    testChara 
}