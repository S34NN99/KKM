using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.InputSystem;

public enum ReviewResponses
{
    None,
    Green,
    Red
}

public class WeightageScoring
{
    public int Score { get; set; }
    public ReviewResponses Review { get; set; }

    public WeightageScoring()
    {
        Score = 0;
        Review = ReviewResponses.Red;
    }
}

public class PlateServed
{
    public enum PlateEvaluation
    {
        Perfect,
        Bad,
    }

    public PlateEvaluation plateEvaluation;

    public PlateServed(Dictionary<Category, WeightageScoring> dish)
    {
        //Check if dish is good or not


        plateEvaluation = ReviewPlate(dish);
        if (plateEvaluation == PlateEvaluation.Perfect)
            GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnServeHealthyFood);
        else
            GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnServeUnhealthyFood);
    }

    //Check if plate is good or not here
    private PlateEvaluation ReviewPlate(Dictionary<Category, WeightageScoring> dish)
    {
        foreach(var dictionary in dish)
        {
            if(dictionary.Value.Review != ReviewResponses.Green)
            {
                return PlateEvaluation.Bad;
            }
        }
        return PlateEvaluation.Perfect;
    }
}

public class PyramidCalculator : MonoBehaviour
{
    [SerializeField] private Poster poster;

    private Dictionary<Category, int> recommendedWeightage = new Dictionary<Category, int>()
    {
        {Category.OilsAndFats, 2},
        { Category.Carb, 12},
        { Category.Dairy, 6}, //this is not being counter to plate TotalWeightage, it is use to track Pyramid Calculation
        { Category.Fruit, 6},
        { Category.Protein, 12},
        { Category.Vege, 18}
    };

    public Dictionary<Category, int> RecommendedWeightage => recommendedWeightage;

    private Dictionary<Category, WeightageScoring> currentWeightage = new Dictionary<Category, WeightageScoring>()
    {
        { Category.OilsAndFats, new WeightageScoring()},
        { Category.Carb, new WeightageScoring()},
        { Category.Dairy, new WeightageScoring()},
        { Category.Fruit, new WeightageScoring()},
        { Category.Protein, new WeightageScoring()},
        { Category.Vege, new WeightageScoring()}
    };

    public Dictionary<Category, WeightageScoring> CurrentWeightageScore
    { 
        get { return currentWeightage; }
        private set 
        { 
            currentWeightage = value; 
        }
    }

    public int TargetAmountForPlateServe;
    private int currentAmountServed = 0;
    public int CurrentAmountServed
    {
        get { return currentAmountServed; }
        set
        {
            currentAmountServed = value;
            if (PlateCounterReached())
            {
                OnGameEnd?.Invoke();
                FindObjectOfType<PlayerInput>().enabled = false;
            }

            trackerAnimator.SetTrigger("IsChanged");
            trackerText.text = $"{currentAmountServed} / {TargetAmountForPlateServe}";
        }
    }

    [Space(10)]
    //private StudentRequest studentRequest;
    [SerializeField] private StudentRequestUpdate studentRequestUpdate;
    [SerializeField] private StatisticTracker st;
    [SerializeField] private GameObject endGameScene;
    [SerializeField] private Plate plate;

    public Action OnGameEnd;
    public Action OnGameEndAfterCoroutine;
    public Action OnServePlate;

    [Header("Tutorial")]
    [Space(20)]
    [SerializeField] private bool isTutorial;
    public UnityEvent EverythingFillExceptDairy;

    private void Start()
    {
        CurrentAmountServed = 0;

        OnServePlate += () => plateServedTracker.Add(new PlateServed(CurrentWeightageScore));
        OnServePlate += () => EvaluatePlateWithMilk(CurrentWeightageScore);
        OnServePlate += () => EvaluatePlateWithoutMilk(CurrentWeightageScore);
        OnServePlate += () => EvaluateGreenBarsPerPlate(CurrentWeightageScore);

        OnServePlate += plate.ResetTimer;
        OnServePlate += ResetWeightage;
        OnServePlate += () => CurrentAmountServed++;

        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.SessionPlayed, 1);
        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.NumberOfCompleteHealtyPlateWithoutDairy, plate.HealtyMealWithoutMilk);
        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.NumberOfCompleteHealtyPlateWithDairy, plate.HealtyMealWithMilk);
        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.AverageImprovementOfFullyHealthyPlate, AmountOfGoodPlates());
        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.NumberOfPlatesDiscard, plate.NumberOfPlatesDiscarded);

        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.Healthy_Students, AmountOfGoodPlates());
        OnGameEndAfterCoroutine += () => st.AddToStatisticDictionary(st.Student_Preferences, plate.SuccessfulServingRequestCounter);
        OnGameEndAfterCoroutine += () => st.PeformStarCalculations(TargetAmountForPlateServe);
        OnGameEnd += () => StartCoroutine(OpenEndGameScene());

        if (!isTutorial)
        {
            OnGameEnd += () => st.RecordTime(false);
            OnGameEndAfterCoroutine += st.UpdateStatsToDatabase;
        }
    }

    private IEnumerator OpenEndGameScene()
    {
        //studentRequestUpdate.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        OnGameEndAfterCoroutine?.Invoke();
        endGameScene.SetActive(true);
        GeneralEventManager.Instance.BroadcastEvent(AudioManager.ResultScreenPlayed);
        FindObjectOfType<PauseManager>().Pause();
    }

    #region tutorial
    private void CheckPyramidScoring()
    {
        if (!isTutorial)
            return;

        if (!FindObjectOfType<TutorialManager>().CheckSlideNumber(4))
            return;

        if (CurrentWeightageScore[Category.Carb].Review != ReviewResponses.Green)
            return;

        if (CurrentWeightageScore[Category.Protein].Review != ReviewResponses.Green)
            return;

        if (CurrentWeightageScore[Category.Fruit].Review != ReviewResponses.Green)
            return;

        if (CurrentWeightageScore[Category.Vege].Review != ReviewResponses.Green)
            return;

        if (CurrentWeightageScore[Category.OilsAndFats].Review != ReviewResponses.Green)
            return;

        EverythingFillExceptDairy?.Invoke();
    }
    #endregion

    #region Pyramid 
    //MAke Action argument to update ReviewResponses and UIs
    private void UpdatePyramidCalculationForOilsAndFats(Category cat)
    {
        float value;
        if (IsBetween(CurrentWeightageScore[cat].Score, 1, RecommendedWeightage[cat], cat, out value))
            CurrentWeightageScore[cat].Review = ReviewResponses.Green;
        else
            CurrentWeightageScore[cat].Review = ReviewResponses.Red;


        poster.OnUIUpdate?.Invoke(cat, (value + 0.5f));
    }

    public void UpdatePyramidCalculation(Category cat)
    {
        if(cat == Category.OilsAndFats)
        {
            UpdatePyramidCalculationForOilsAndFats(cat);   
            return;
        }

        float value = CompareWeightage(cat);
        if(value == 1)
            CurrentWeightageScore[cat].Review = ReviewResponses.Green;
        else if(value > 1)
            CurrentWeightageScore[cat].Review = ReviewResponses.Red;

        CheckPyramidScoring();
        poster.OnUIUpdate?.Invoke(cat, value);
    }

    public void AddToCurrentCalculator(Ingredient ingredient)
    {
        if (ingredient.HasFats)
        {
            CurrentWeightageScore[Category.OilsAndFats].Score++;
            UpdatePyramidCalculation(Category.OilsAndFats);
        }

        CurrentWeightageScore[ingredient.Category].Score += ingredient.Weightage;
        UpdatePyramidCalculation(ingredient.Category);
    }

    private float CompareWeightage(Category cat)
    {
        float value = (float)CurrentWeightageScore[cat].Score / (float)RecommendedWeightage[cat];
        return value;
    }

    private bool IsBetween(float currentValue, float value1, float value2, Category cat, out float value)
    {
        value = CompareWeightage(cat);
        return (currentValue >= Math.Min(value1, value2) && currentValue <= Math.Max(value1, value2));
    }
    #endregion

    #region Plate Serve Tracker
    private List<PlateServed> plateServedTracker = new List<PlateServed>();
    [SerializeField] private Text trackerText;
    [SerializeField] private Animator trackerAnimator;

    public bool PlateCounterReached()
    {
        return currentAmountServed >= TargetAmountForPlateServe;
    }

    public void ResetWeightage()
    {
        CurrentWeightageScore = new Dictionary<Category, WeightageScoring>()
        {
            { Category.OilsAndFats, new WeightageScoring()},
            { Category.Carb, new WeightageScoring()},
            { Category.Dairy, new WeightageScoring()},
            { Category.Fruit, new WeightageScoring()},
            { Category.Protein, new WeightageScoring()},
            { Category.Vege, new WeightageScoring()}
        };
    }

    private int AmountOfGoodPlates()
    {
        int counter = 0;

        foreach(PlateServed ps in plateServedTracker)
        {
            if (ps.plateEvaluation == PlateServed.PlateEvaluation.Perfect)
                counter++;
        }

        return counter;
    }


    private void EvaluatePlateWithoutMilk(Dictionary<Category, WeightageScoring> dish)
    {
        foreach (var dictionary in dish)
        {
            if (dictionary.Key == Category.Dairy)
                continue;

            if (dictionary.Value.Review != ReviewResponses.Green)
                return;
        }

        FindObjectOfType<Plate>().HealtyMealWithoutMilk++;
        plate.startRecordTimeForPlate = false;
        st.AddToStatisticDictionary(st.AverageDurationToCompleteAHealthyPlateWithoutDairy, plate.DurationForAHealthyMeal);
    }

    private void EvaluatePlateWithMilk(Dictionary<Category, WeightageScoring> dish)
    {
        foreach (var dictionary in dish)
        {
            if (dictionary.Value.Review != ReviewResponses.Green)
                return;
        }

        FindObjectOfType<Plate>().HealtyMealWithMilk++;
        plate.startRecordTimeForPlate = false;
        st.AddToStatisticDictionary(st.AverageDurationToCompleteAHealthyPlateWithDairy, plate.DurationForAHealthyMeal);
    }

    private void EvaluateGreenBarsPerPlate(Dictionary<Category, WeightageScoring> dish)
    {
        int counter = 0;
        foreach(var dictionary in dish)
        {
            if (dictionary.Value.Review == ReviewResponses.Green)
                counter++;
        }

        st.AddToStatisticDictionary(st.AverageGreenBarsPerPlate, counter);
    }

    #endregion



}
