using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationManager : MonoBehaviour
{
    [SerializeField] private bool isPlayedInBM;
    public bool IsPlayedInBM => isPlayedInBM;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("PlayedInMalay"))
        {
            isPlayedInBM = PlayerPrefs.GetInt("PlayedInMalay", 0) == 0 ? false : true;
        }
        else
        {
            PlayerPrefs.SetInt("PlayedInMalay", 0);
            isPlayedInBM = false;
        }

        ChangeButtonUI();
    }

    public void ChangeButtonUI()
    {
        var button = FindObjectsOfType<ButtonHitBox>();
        foreach(var bb in button)
        {
            bb.ApplyCorrectButtonImage();
        }
    }

    public void CheckLanguage()
    {
        var trigger = FindObjectsOfType<TranslationTrigger>();
        foreach(var tt in trigger)
        {
            if (isPlayedInBM)
                tt.SwitchToMalay();
            else
                tt.SwitchToEnglish();
        }
    }

    public void ToEnglish()
    {
        isPlayedInBM = false;
        PlayerPrefs.SetInt("PlayedInMalay", 0);
    }

    public void ToMalay()
    {
        isPlayedInBM = true;
        PlayerPrefs.SetInt("PlayedInMalay", 1);
    }
}
