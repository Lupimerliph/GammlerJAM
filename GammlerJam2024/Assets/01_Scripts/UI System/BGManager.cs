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
    public Sprite lobbyBG, funZoneBG, cafeteriaBG, toiletBG, currentRoomBG;
    public float minBlackTime = 1, minZoomTime = 1, endingFade; //sonst ist die Überblende zu schnell
    public Vector3 kalenderZoomPos, kalenderZoomScale;
    Tween blackTween;
    public Sprite[] endImage;  


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentRoomBG = spriteRenderer.sprite;
        blackScreen.color = new Color(0,0,0,1);
    }

    public void Flicker()
    {
        //add sfx later
        blackScreen.DOFade(0, 4).SetEase(Ease.InBounce);
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
            case room.toilet:
                currentRoomBG = toiletBG;
                break;
        }
        StartCoroutine(FadeToBlack(1));
    }
    
    public IEnumerator FadeToBlack(float fadeDuration)
    {        
        blackScreen.DOFade(1, fadeDuration);        
        yield return new WaitForSeconds(fadeDuration + minBlackTime);
        spriteRenderer.sprite = currentRoomBG;
        blackScreen.DOFade(0, fadeDuration);
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

    public IEnumerator EddyFlicker()
    {
        yield return null;
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
    lobby, bureau, cafeteria, toilet
}
