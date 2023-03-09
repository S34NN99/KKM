using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button musicOn;
    [SerializeField] private Button musicOff;
    [SerializeField] private Button english;
    [SerializeField] private Button bm;

    private void CheckButtonsInteractbility()
    {
        bool isPlayedinBM;
        isPlayedinBM = PlayerPrefs.GetInt("PlayedInMalay", 0) == 0 ? false : true;
        english.interactable = isPlayedinBM;
        bm.interactable = !isPlayedinBM;
        Debug.Log("Checking");

        bool isMuted;
        isMuted = PlayerPrefs.GetInt("Volume", 1) == 0 ? false : true;
        musicOn.interactable = !isMuted;
        musicOff.interactable = isMuted;
    }

    private void OnEnable()
    {
        CheckButtonsInteractbility();
    }
}
