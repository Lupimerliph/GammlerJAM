using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using DG.Tweening;

public class DiaActivator : MonoBehaviour
{
    public charaID thisChara;
    public float transitionDuration; //shorter = more speed
    public Vector3 originPosition, fullPosition, originScale;

    private void Start()
    {
        originPosition = transform.localPosition;
        originScale = transform.localScale;
    }

    private void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0) && !DialogManager.diaManager.inConversation)
        {            
            ConversationManager.Instance.StartConversation(DialogManager.diaManager.SetCurrentDialog(thisChara));
            MoveCharacter(fullPosition, Vector3.one);
            DialogManager.diaManager.currentSpeaker = this;
        }             
    }

    public void MoveCharacter(Vector3 destinationPos, Vector3 destinationScale) //move Chara to front or back
    {
        transform.DOLocalMove(destinationPos, transitionDuration);
        transform.DOScale(destinationScale, transitionDuration);
    }
}
