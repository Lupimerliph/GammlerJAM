using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogManager : MonoBehaviour
{
    public static DialogManager diaManager;
    public charaID currentChara;
    public GameObject currentDialog;
    public GameObject testDia, milDia, enDia, pebDia, bearDia, friDia, pabloDia, mcDia;  

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
            case charaID.testChara:
                currentDialog = testDia;
                break;
            case charaID.millie:
                currentDialog = milDia;
                break;
            case charaID.enrico:
                currentDialog = enDia;
                break;
            case charaID.pebbles:
                currentDialog = pebDia;
                break;
            case charaID.bearnand:
                currentDialog = bearDia;
                break;
            case charaID.fritz:
                currentDialog = friDia;
                break;
            case charaID.pablo:
                currentDialog = pabloDia;
                break;
            case charaID.mc:
                currentDialog = mcDia;
                break;
        }

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