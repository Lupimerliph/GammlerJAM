using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BGManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public room thisRoom;
    public Image blackScreen;
    public Sprite lobbyBG, funZoneBG, cafeteriaBG, toiletBG, currentRoomBG;
    public float minBlackTime = 1, minZoomTime = 1; //sonst ist die Überblende zu schnell
    public Vector3 kalenderZoomPos, kalenderZoomScale;

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
        float timePassed = 0;
        blackScreen.DOFade(1, fadeDuration);
        while (timePassed < fadeDuration + minBlackTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.sprite = currentRoomBG;
        blackScreen.DOFade(0, fadeDuration);
    }

    public IEnumerator ZoomOnCalender(float zoomDuration)
    {
        float timePassed = 0;
        transform.DOLocalMove(kalenderZoomPos, zoomDuration);
        transform.DOScale(kalenderZoomScale, zoomDuration);

        while (timePassed < zoomDuration + minBlackTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        transform.DOLocalMove(Vector3.zero, zoomDuration);
        transform.DOScale(Vector3.one, zoomDuration);

        blackScreen.DOFade(0, zoomDuration);
    }

}

public enum room
{
    lobby, bureau, cafeteria, toilet
}
