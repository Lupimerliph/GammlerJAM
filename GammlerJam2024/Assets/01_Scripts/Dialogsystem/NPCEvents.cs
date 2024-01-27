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

    public void BlackFade()//evtl mit variabler Länge
    {
        //call to gmManager
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
