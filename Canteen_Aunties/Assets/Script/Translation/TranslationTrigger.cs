using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslationTrigger : MonoBehaviour
{
    [SerializeField] private Translation translationText;

    private void Start()
    {
        if (FindObjectOfType<TranslationManager>().IsPlayedInBM)
            GetComponent<Text>().text = translationText.MalayText;
        else
            GetComponent<Text>().text = translationText.EnglishText;
    }

    public void SwitchToEnglish()
    {
        GetComponent<Text>().text = translationText.EnglishText;
    }

    public void SwitchToMalay()
    {
        GetComponent<Text>().text = translationText.MalayText;
    }


}
