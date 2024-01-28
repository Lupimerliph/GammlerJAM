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
        DialogManager.diaManager.currentSpeaker.SwitchPose(emoteID);
    }

    #region Eddy
    public void FlickeringLights()
    {
        GameManager.gmManager.bgManager.Flicker();
    }

    public void EddyFirstEncounter()
    {
        StartCoroutine(GameManager.gmManager.bgManager.EddyFirstEncounter());
    }
    public void EddyFlickers()
    {
        GameManager.gmManager.bgManager.EddyFlicker();
    }

    public void FritzchenReveal()
    {
        StartCoroutine(GameManager.gmManager.bgManager.EddyReveal());
    }
    #endregion

    public void SetNewStartingPoint(GameObject diaObject)
    {
        DialogManager.diaManager.SetNewConvo(diaObject);
    }
        
    public void LookAtKalendar()
    {
        StartCoroutine(GameManager.gmManager.bgManager.ZoomOnCalender(3));
    }

    public void TriggerEnd(int endID)
    {
        StartCoroutine(GameManager.gmManager.bgManager.AnEnd(endID));
    }

    public void CharacterLeaves(float fadeLength)
    {
        DialogManager.diaManager.SpeakerLeaves(fadeLength);
    }
}
