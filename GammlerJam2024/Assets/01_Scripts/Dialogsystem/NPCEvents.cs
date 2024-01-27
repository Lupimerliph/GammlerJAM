using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEvents : MonoBehaviour
{
    public void ChangeRoom(string newRoom)
    {
        if(System.Enum.TryParse(newRoom, out room myRoom))
        {
            GameManager.gmManager.bgManager.SetBG(myRoom);
        }
    }

    public void BlackFade(int fadeDuration)//evtl mit variabler Länge
    {
        StartCoroutine(GameManager.gmManager.bgManager.FadeToBlack(fadeDuration));
    }

    public void ChangeEmote(int emoteID)
    {

    }

    public void GetItem()
    {

    }

    public void WeHadThisConversation()
    {
        //need ref to the chara
    }
        

}
