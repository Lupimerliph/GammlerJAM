using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using DG.Tweening;

public class DialogManager : MonoBehaviour
{
    public static DialogManager diaManager;
    public charaID currentChara;
    public bool inConversation; //sp�ter verhindern, dass Sprite �fters angeklickt werden kann.
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ConversationManager.Instance.ScrollSpeed = 0.25f;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            ConversationManager.Instance.ScrollSpeed = 1;
        }
    }

    public NPCConversation SetCurrentDialog(charaID chara)
    {
        currentChara = chara; 
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
        currentSpeaker.HideNonSpeaker(true);
        Debug.Log("This Conversation is over");
    }

    public void SpeakerLeaves(float fadeLength)
    {
        currentSpeaker.GetComponent<Collider2D>().enabled = false;
        currentSpeaker.spriteRenderer.DOColor(Color.clear, fadeLength);
    }

    public void SetNewConvo(GameObject ConvoObj)
    {
        mcDia = ConvoObj.GetComponent<NPCConversation>();//Problem der Zukunft: Script funktioniert nur mit mc grad
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