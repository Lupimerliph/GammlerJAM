using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogManager : MonoBehaviour
{
    public static DialogManager diaManager;
    public charaID currentChara;
    public GameObject currentDialog;


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
        NPCConversation convo = currentDialog.GetComponent<NPCConversation>();
        return convo;

    } 

}

public enum charaID
{
    testChara,
    millie,
    enrico, 
    pebbles,
    bearnand,
    fritz,
    pablo,
    mc
}