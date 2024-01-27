using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BGManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Image blackScreen;
    public Sprite lobbyBG, funZoneBG, cafeteriaBG, toiletBG;
    public float minBlackTime = 1; //sonst ist die Überblende zu schnell

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBG(room currentRoom)
    {
        switch (currentRoom)
        {
            case room.lobby:
                spriteRenderer.sprite = lobbyBG;
                break;
            case room.bureau:
                spriteRenderer.sprite = funZoneBG;
                break;
            case room.cafeteria:
                spriteRenderer.sprite = cafeteriaBG;
                break;
            case room.toilet:
                spriteRenderer.sprite = toiletBG;
                break;
        }
    }

    public IEnumerator FadeToBlack(int fadeDuration)
    {
        Debug.Log("started Fade");
        float timePassed = 0;
        blackScreen.DOFade(1, fadeDuration);
        while (timePassed < fadeDuration + minBlackTime)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        blackScreen.DOFade(0, fadeDuration);
        Debug.Log("ended Fade");

    }

}

public enum room
{
    lobby, bureau, cafeteria, toilet
}
