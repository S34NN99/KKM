using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class MainBG
    {
        public bool playOnFirstLogin;
        public AudioClip[] mainBgclips;
    }

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
    public const string OnButtonGamePlayed = "OnButtonGamePlayed";

    public const string OnFoodDroppedDry = "OnFoodDroppedDry";
    public const string OnFoodDroppedWet = "OnFoodDroppedWet";
    public const string OnFoodDroppedCrispy = "OnFoodDroppedCrispy";
    public const string OnFoodDroppedPorridge = "OnFoodDroppedPorridge";
    public const string OnFoodPickUp = "OnFoodPickUp";

    public const string OnServingFood = "OnServingFood";
    public const string OnThrowingFood = "OnThrowingFood";
    public const string OnTrayMove = "OnTrayMove";

    public const string OnServeHealthyFood = "OnServerHealthyFood";
    public const string OnServeUnhealthyFood = "OnServeUnhealtyFood";
    public const string OnFoodWeightageReached = "OnFoodWeightageReached";
    public const string OnTimeRunsOut = "OnTimeRunsOut";
    public const string OnRandomButtonPresses = "OnRandomButtonPresses";
    public const string OnFailedLogin = "OnFailedLogin";

    public const string OnServeStudentPreference = "OnServeStudentPreference";
    public const string ResultScreenPlayed = "ResultScreenPlayed";
    public const string OnLevelStart = "OnLevelStart";
    public const string OnCountdownOneAndTwo = "OnCountdownOneAndTwo";
    public const string OnCountdownThree = "OnCountdownThree";

    public const string CanteenAmbient = "CanteenAmbient";
    public const string OnGameSceneBG = "OnGameSceneBG";
    public const string OnMainMenuBG = "OnMainMenuBG";

    [SerializeField] private bool isGameScene;

    [Header("Clips")]
    [Space()]
    [SerializeField] private AudioClip[] onButtonPressed;
    [SerializeField] private AudioClip onButtonGamePlayed;

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
    [SerializeField] private AudioClip onServeHealthyFood;
    [SerializeField] private AudioClip negativeAction;

    [Space()]
    [SerializeField] private AudioClip resultScreenPlayed;
    [SerializeField] private AudioClip onLevelStart;
    [SerializeField] private AudioClip onCountdownOneAndTwo;
    [SerializeField] private AudioClip onCountdownThree;

    [Space()]
    [SerializeField] private AudioClip canteenAmbient;
    [SerializeField] private AudioClip onGameSceneBG;
    [SerializeField] private MainBG onMainMenuBG;

    [Space()]
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgMusicPlayer;
    [SerializeField] private AudioSource canteenAmbientPlayer;
    [SerializeField] private AudioSource uiSfxPlayer;
    [SerializeField] private AudioSource foodPickedSfxPlayer;
    [SerializeField] private AudioSource foodDropSfxPlayer;
    [SerializeField] private AudioSource plateServingSfxPlayer;
    [SerializeField] private AudioSource gameSceneSfxPlayer;


    private void Start()
    {
        GeneralEventManager.Instance.StartListeningTo(OnButtonPressed, () =>
        {
            int randomNum = Random.Range(0, onButtonPressed.Length);
            uiSfxPlayer.clip = onButtonPressed[randomNum];
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnButtonGamePlayed, () =>
        {
            uiSfxPlayer.clip = onButtonGamePlayed;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(CanteenAmbient, () =>
        {
            canteenAmbientPlayer.clip = canteenAmbient;
            canteenAmbientPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodDroppedDry, () =>
        {
            foodDropSfxPlayer.clip = onFoodDroppedDry;
            foodDropSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodDroppedWet, () =>
        {
            foodDropSfxPlayer.clip = onFoodDroppedWet;
            foodDropSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodDroppedCrispy, () =>
        {
            foodDropSfxPlayer.clip = onFoodDroppedCrispy;
            foodDropSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodDroppedPorridge, () =>
        {
            foodDropSfxPlayer.clip = onFoodDroppedPorridge;
            foodDropSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodPickUp, () =>
        {
            foodPickedSfxPlayer.clip = onFoodPickUp;
            foodPickedSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnServingFood, () =>
        {
            uiSfxPlayer.clip = onServingFood;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnThrowingFood, () =>
        {
            uiSfxPlayer.clip = onThrowingFood;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnTrayMove, () =>
        {
            uiSfxPlayer.clip = onTrayMove;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnServeUnhealthyFood, () =>
        {
            plateServingSfxPlayer.clip = negativeAction;
            plateServingSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFoodWeightageReached, () =>
        {
            foodPickedSfxPlayer.clip = negativeAction;
            foodPickedSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnTimeRunsOut, () =>
        {
            gameSceneSfxPlayer.clip = negativeAction;
            gameSceneSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnRandomButtonPresses, () =>
        {
            uiSfxPlayer.clip = negativeAction;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnFailedLogin, () =>
        {
            uiSfxPlayer.clip = negativeAction;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnServeHealthyFood, () =>
        {
            plateServingSfxPlayer.clip = onServeHealthyFood;
            plateServingSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(ResultScreenPlayed, () =>
        {
            gameSceneSfxPlayer.clip = resultScreenPlayed;
            gameSceneSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnServeStudentPreference, () =>
        {
            gameSceneSfxPlayer.clip = resultScreenPlayed;
            gameSceneSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnLevelStart, () =>
        {
            gameSceneSfxPlayer.clip = onLevelStart;
            gameSceneSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnCountdownOneAndTwo, () =>
        {
            uiSfxPlayer.clip = onCountdownOneAndTwo;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnCountdownThree, () =>
        {
            uiSfxPlayer.clip = onCountdownThree;
            uiSfxPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnGameSceneBG, () =>
        {
            bgMusicPlayer.clip = onGameSceneBG;
            bgMusicPlayer.Play();
        });

        GeneralEventManager.Instance.StartListeningTo(OnMainMenuBG, () =>
        {
            bgMusicPlayer.clip = onMainMenuBG.mainBgclips[0];
            bgMusicPlayer.Play();
        });

        if(isGameScene)
        {
            GeneralEventManager.Instance.BroadcastEvent(OnLevelStart);
            GeneralEventManager.Instance.BroadcastEvent(OnGameSceneBG);
            GeneralEventManager.Instance.BroadcastEvent(CanteenAmbient);
        }
        else
        {
            GeneralEventManager.Instance.BroadcastEvent(OnMainMenuBG);
        }
    }

    public void BroadCastEvent(string eventName)
    {
        GeneralEventManager.Instance.BroadcastEvent(eventName);
    }

}
