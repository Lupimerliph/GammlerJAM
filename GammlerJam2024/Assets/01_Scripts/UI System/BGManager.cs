using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite lobbyBG, funZoneBG, cafeteriaBG, toiletBG;

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
}

public enum room
{
    lobby, bureau, cafeteria, toilet
}
