using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static void SetBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat("Bgm_Volume", volume);
        CheckAudioSourcesInScene();
    }

    public static void SetSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat("Sfx_Volume", volume);
        CheckAudioSourcesInScene();
    }

    public static void CheckAudioSourcesInScene()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            //audioManager.CheckBgmAndSfxMute();
        }

        float bgmVolume = PlayerPrefs.GetFloat("Bgm_Volume", 1);
        float sfxVolume = PlayerPrefs.GetFloat("Sfx_Volume", 1);

        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            string objName = audioSource.gameObject.name.ToUpper();
            if (objName.StartsWith("BGM") || objName.EndsWith("BGM"))
            {
                audioSource.volume = bgmVolume;
            }
            else if (objName.StartsWith("SFX") || objName.StartsWith("SFX"))
            {
                audioSource.volume = sfxVolume;
            }
        }
    }

    public static void ToggleBgm()
    {
        float volume = PlayerPrefs.GetFloat("Bgm_Volume", 1);
        if (volume == 1f)
        {
            SetBgmVolume(0);
        }
        else
        {
            SetBgmVolume(1);
        }
    }

    public static void ToggleSfx()
    {
        float volume = PlayerPrefs.GetFloat("Sfx_Volume", 1);
        if (volume == 1f)
        {
            SetSfxVolume(0);
        }
        else
        {
            SetSfxVolume(1);
        }
    }

    public const string OnButtonPressed = "OnButtonPressed";
    public const string OnGamePlayed = "OnGamePlayed";

    public const string OnFoodDroppedDry = "OnFoodDroppedDry";
    public const string OnFoodDroppedWet = "OnFoodDroppedWet";
    public const string OnFoodDroppedCrispy = "OnFoodDroppedCrispy";
    public const string OnFoodDroppedPorridge = "OnFoodDroppedPorridge";
    public const string OnFoodPickUp = "OnFoodPickUp";

    public const string OnServingFood = "OnServingFood";
    public const string OnThrowingFood = "OnThrowingFood";
    public const string OnTrayMove = "OnTrayMove";

    public const string OnServeHealtyFood = "OnServerHealtyFood";
    public const string OnServeUnhealtyFood = "OnServeUnhealtyFood";
    public const string OnFoodWeightageReached = "OnFoodWeightageReached";
    public const string OnTimeRunsOut = "OnTimeRunsOut";
    public const string OnRandomButtonPresses = "OnRandomButtonPresses";
    public const string OnFailedLogin = "OnFailedLogin";

    public const string ResultScreenPlayed = "ResultScreenPlayed";
    public const string OnLevelStart = "OnLevelStart";
    public const string OnCountdownOne = "OnCountDownOne";
    public const string OnCountdownTwo = "OnCountDownTwo";
    public const string OnCountdownThree = "OnCountDownThree";

    public const string CanteenAmbient = "CanteenAmbient";
    public const string OnGameSceneBG = "OnGameSceneBG";
    public const string OnMainMenuBG = "OnMainMenuBG";

    [Header("Clips")]
    [Space()]
    [SerializeField] private AudioClip onButtonPressed;
    [SerializeField] private AudioClip onGamePlayed;

    [Space()]
    [SerializeField] private AudioClip onFoodDroppedDry;
    [SerializeField] private AudioClip onFoodDroppedWet;
    [SerializeField] private AudioClip onFoodDroppedCrispy;
    [SerializeField] private AudioClip onFoodDroppedPorridge;
    [SerializeField] private AudioClip onFoodPickUp;
    [SerializeField] private AudioClip onServingFood;
    [SerializeField] private AudioClip onThrowingFood;

    [Space()]
    [SerializeField] private AudioClip onTrayMove;
    [SerializeField] private AudioClip onServeHealtyFood;
    [SerializeField] private AudioClip onServeUnhealtyFood;
    [SerializeField] private AudioClip onFoodWeightageReached;
    [SerializeField] private AudioClip onTimeRunsOut;
    [SerializeField] private AudioClip onRandomButtonPresses;
    [SerializeField] private AudioClip onFailedLogin;

    [Space()]
    [SerializeField] private AudioClip resultScreenPlayed;
    [SerializeField] private AudioClip onLevelStart;
    [SerializeField] private AudioClip onCountdownOne;
    [SerializeField] private AudioClip onCountdownTwo;
    [SerializeField] private AudioClip onCountdownThree;

    [Space()]
    [SerializeField] private AudioClip canteenAmbient;
    [SerializeField] private AudioClip onGameSceneBG;
    [SerializeField] private AudioClip[] onMainMenuBG;

    [Space()]
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgMusicPlayer;
    [SerializeField] private AudioSource uiSfxPlayer;

    private void Start()
    {
        GeneralEventManager.Instance.StartListeningTo(OnButtonPressed, () =>
        {
            uiSfxPlayer.clip = onButtonPressed;
            uiSfxPlayer.Play();
        });


    }

}
