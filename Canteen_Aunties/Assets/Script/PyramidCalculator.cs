using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ReviewResponses
{
    None,
    Grey,
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
        Review = ReviewResponses.None;
    }
}

public class PlateServed
{
    public enum PlateEvaluation
    {
        Perfect,
        Good,
        Bad,
    }

    public PlateEvaluation plateEvaluation;

    public PlateServed(Dictionary<Category, WeightageScoring> dish)
    {
        //Check if dish is good or not
        plateEvaluation = ReviewPlate(dish);
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

    public Dictionary<Category, WeightageScoring> CurrentWeightage
    { 
        get { return currentWeightage; }
        private set { currentWeightage = value; }
    }

    [SerializeField] private int TargetAmountForPlateServe;
    private int currentAmountServed = 0;
    public int CurrentAmountServed
    {
        get { return currentAmountServed; }
        set
        {
            currentAmountServed = value;
            if (currentAmountServed >= TargetAmountForPlateServe)
            {
                OnGameEnd?.Invoke();
            }

            trackerText.text = $"{currentAmountServed} / {TargetAmountForPlateServe}";
        }
    }

    [Space(10)]
    [SerializeField] private StudentRequest studentRequest;
    [SerializeField] private StatisticTracker st;
    [SerializeField] private GameObject endGameScene;

    public Action OnGameEnd;
    public Action OnServePlate;

    private void Start()
    {
        CurrentAmountServed = 0;

        OnServePlate += () => plateServedTracker.Add(new PlateServed(CurrentWeightage));
        OnServePlate += ResetWeightage;
        OnServePlate += () => CurrentAmountServed++;

        OnGameEnd += () => endGameScene.SetActive(true);
        OnGameEnd += () => st.AddToStatisticDictionary(st.Healthy_Students, AmountOfGoodPlates());
        OnGameEnd += () => st.AddToStatisticDictionary(st.Meal_Requirement, AmountOfGoodPlates());
        OnGameEnd += () => st.AddToStatisticDictionary(st.Student_Preferences, studentRequest.SuccessfulServingCounter);
        OnGameEnd += () => st.PeformStarCalculations(TargetAmountForPlateServe);
        
        OnGameEnd += st.UpdateStatsToDatabase;
        OnGameEnd += () => FindObjectOfType<PauseManager>().Pause();
    }

    #region Pyramid 
    //MAke Action argument to update ReviewResponses and UIs
    public void UpdatePyramidCalculation(Category cat)
    {
        if(cat == Category.OilsAndFats)
        {
            if (IsBetween(CurrentWeightage[cat].Score, 1, RecommendedWeightage[cat]))
            {
                CurrentWeightage[cat].Review = ReviewResponses.Green;
                poster.OnUIUpdate?.Invoke(Color.green, cat);
            }
            else
            {
                CurrentWeightage[cat].Review = ReviewResponses.Red;
                poster.OnUIUpdate?.Invoke(Color.red, cat);
            }
            return;
        }

        float value = CompareWeightage(cat);
        if(value == 1)
        {
            //Perfect make it green;
            CurrentWeightage[cat].Review = ReviewResponses.Green;
            poster.OnUIUpdate?.Invoke(Color.green, cat);
        }
        else if(value < 1)
        {
            //make it gray
            //CurrentWeightage[cat].Review = ReviewResponses.Grey;
            //poster.OnUIUpdate?.Invoke(Color.black, cat);
        }
        else 
        {
            //make it red
            CurrentWeightage[cat].Review = ReviewResponses.Red;
            poster.OnUIUpdate?.Invoke(Color.red, cat);
        }
    }

    public void AddToCurrentCalculator(Ingredient ingredient)
    {
        if (ingredient.HasFats)
        {
            CurrentWeightage[Category.OilsAndFats].Score++;
            UpdatePyramidCalculation(Category.OilsAndFats);
        }

        CurrentWeightage[ingredient.Category].Score += ingredient.Weightage;
        UpdatePyramidCalculation(ingredient.Category);
    }

    private float CompareWeightage(Category cat)
    {
        float value = (float)CurrentWeightage[cat].Score / (float)RecommendedWeightage[cat];
        return value;
    }

    private bool IsBetween(float currentValue, float value1, float value2)
    {
        return (currentValue >= Math.Min(value1, value2) && currentValue <= Math.Max(value1, value2));
    }


    #endregion

    #region Plate Serve Tracker
    private List<PlateServed> plateServedTracker = new List<PlateServed>();
    [SerializeField] private Text trackerText;

    public void ResetWeightage()
    {
        CurrentWeightage = new Dictionary<Category, WeightageScoring>()
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

    #endregion


    
}
