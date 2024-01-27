using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using DG.Tweening;

public class DiaActivator : MonoBehaviour
{
    public charaID thisChara;
    public room charaRoom;
    public float transitionDuration; //shorter = more speed
    public Vector3 originPosition, fullPosition, originScale;
    public Sprite defaultPose, pose1, pose2, pose3, pose4;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        originPosition = transform.localPosition;
        originScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(charaRoom!= GameManager.gmManager.bgManager.thisRoom)
        {
            ActiveCharacter(false);
        }
    }

    void ActiveCharacter(bool status)
    {
        spriteRenderer.enabled = status;
        GetComponent<Collider2D>().enabled = status;
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
    public void SwitchPose(int poseID)
    {        
        switch (poseID)
        {
            case 0:
                spriteRenderer.sprite = defaultPose;
                break;
            case 1:
                spriteRenderer.sprite = pose1;
                break;
            case 2:
                spriteRenderer.sprite = pose2;
                break;
            case 3:
                spriteRenderer.sprite = pose3;
                break;
            case 4:
                spriteRenderer.sprite = pose4;
                break;
        }
         
    }

    public void MoveCharacter(Vector3 destinationPos, Vector3 destinationScale) //move Chara to front or back
    {
        transform.DOLocalMove(destinationPos, transitionDuration);
        transform.DOScale(destinationScale, transitionDuration);
    }
        
}
