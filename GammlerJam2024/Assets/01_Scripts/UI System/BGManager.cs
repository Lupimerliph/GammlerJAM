using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DialogueEditor;


public class BGManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public room thisRoom;
    public Image blackScreen, endScreen;
    public Sprite lobbyBG, funZoneBG, cafeteriaBG, schrankBG, currentRoomBG;
    public float minBlackTime = 1, minZoomTime = 1, endingFade; //sonst ist die Überblende zu schnell
    public Vector3 kalenderZoomPos, kalenderZoomScale;
    Tween blackTween, eddyTween;
    public Sprite[] endImage;
    public DiaActivator eddy, mc;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentRoomBG = spriteRenderer.sprite;
        blackScreen.color = new Color(0,0,0,1);
    }

    public void SetBG(room currentRoom)
    {
        thisRoom = currentRoom;
        switch (currentRoom)
        {
            case room.lobby:
                currentRoomBG = lobbyBG;
                break;
            case room.bureau:
                currentRoomBG = funZoneBG;
                break;
            case room.cafeteria:
                currentRoomBG = cafeteriaBG;
                break;
            case room.shelves:
                currentRoomBG = schrankBG;
                break;
        }
        StartCoroutine(FadeToBlack(1));
        mc.charaRoom = currentRoom;
    }
    
    public IEnumerator FadeToBlack(float fadeDuration)
    {        
        blackScreen.DOFade(1, fadeDuration);        
        yield return new WaitForSeconds(fadeDuration + minBlackTime);
        spriteRenderer.sprite = currentRoomBG;
        DialogManager.diaManager.currentSpeaker.HideNonSpeaker(true);
        blackTween = blackScreen.DOFade(0, fadeDuration);
    }

    public void Flicker()
    {
        //add sfx later
        blackScreen.DOFade(0, 4).SetEase(Ease.InBounce);
    }

    public IEnumerator ZoomOnCalender(float zoomDuration)
    {
        transform.DOLocalMove(kalenderZoomPos, zoomDuration);
        transform.DOScale(kalenderZoomScale, zoomDuration);
            yield return new WaitForSeconds(zoomDuration + minBlackTime);
        transform.DOLocalMove(Vector3.zero, zoomDuration);
        transform.DOScale(Vector3.one, zoomDuration);

        blackScreen.DOFade(0, zoomDuration);
    }
    
    public void EddyFlicker()
    {
        eddy.spriteRenderer.DOColor(Color.white, 4).SetEase(Ease.InBounce);
    }
    public IEnumerator EddyFirstEncounter()
    {
        if (!eddy.charaLeft)
        {
            yield return new WaitForSeconds(1 + minBlackTime);
            DOTween.KillAll();
            eddy.transform.localPosition = eddy.originPosition - new Vector3(0, 10, 0);
            eddy.spriteRenderer.color = Color.gray;
            eddy.spriteRenderer.sortingOrder = 8;
            eddyTween = eddy.transform.DOLocalMoveY(eddy.originPosition.y, 5);
        }
    }
    public IEnumerator EddyReveal()
    {
        eddy.spriteRenderer.sortingOrder = 0;
        blackScreen.color = Color.black;
        yield return new WaitForSeconds(3); //switch pose ist als event im dia editor
        blackScreen.color = Color.clear;

    }


    public IEnumerator AnEnd(int endID)
    {
        ConversationManager.Instance.enabled = false;        
        endScreen.raycastTarget = true;
        endScreen.sprite = endImage[endID];
        endScreen.color = new Color(0, 0, 0, 0);
        endScreen.DOFade(1, endingFade);
        yield return new WaitForSeconds(endingFade);
        endScreen.DOColor(Color.white, endingFade);
    }

}

public enum room
{
    lobby, bureau, cafeteria, shelves, none
}
