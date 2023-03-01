using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class TutorialSlideContainter
{
    public TutorialSlide tutorialSlides;
    [SerializeField] private GameObject slideObject;
    public GameObject Slide => slideObject;
}

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialStateDatabase tutorialDB;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private List<TutorialSlideContainter> _slideContainer;
    public List<TutorialSlideContainter> SliderContainer => _slideContainer;

    private Dictionary<string, int> _attributes;
    public Dictionary<string, int> Attributes => _attributes;

    private int _slideCounter;
    public int SlideCounter
    {
        get { return _slideCounter; }
        private set 
        { 
            _slideCounter = value;
        }
    }

    public void Start()
    {
        _attributes = new Dictionary<string, int>();
        InitializeTracker();

        SliderContainer[0].tutorialSlides = new FirstSlide();
        SliderContainer[1].tutorialSlides = new SecondSlide();
        SliderContainer[2].tutorialSlides = new ThirdSlide();
        SliderContainer[3].tutorialSlides = new FourthSlide();
        SliderContainer[4].tutorialSlides = new FifthSlide();
        SliderContainer[5].tutorialSlides = new SixthSlide();
    }

    #region tracker
    private void InitializeTracker()
    {
        foreach(string i in tutorialDB.BoolStateNames)
        {
            SetBoolean(i, 0);
        }
    }

    public int GetState(string state)
    {
        Attributes.TryGetValue(state, out int stateVal);
        return stateVal;
    }

    public void SetBoolean(string state, int value)
    {
        if (GetState(state) == value) return;

        if (Attributes.ContainsKey(state))
        {
            Attributes[state] = value;
        }
        else
        {
            Attributes.Add(state, value);
        }
    }

    public void AddBoolean(string state) => SetBoolean(state, 1);

    public void AddBooleanWithDelay(string state) => StartCoroutine(AddBooleanWithDelayCoroutine(state));

    public IEnumerator AddBooleanWithDelayCoroutine(string state)
    {
        yield return new WaitForSeconds(1f);
        SetBoolean(state, 1);
    }


    #endregion

    public void Update()
    {
        EvaluateAttributes();
    }

    private void EvaluateAttributes()
    {
        if (SlideCounter >= SliderContainer.Count) return;

        if (SliderContainer[SlideCounter].tutorialSlides.EvaluateConditions(Attributes))
        {
            SliderContainer[SlideCounter].Slide.SetActive(true);
            SlideCounter++;
        }
    }

    public bool CheckSlideNumber(int num)
    {
        return SlideCounter == num;
    }
}
