using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Debug.Log("Added to Plate Served");
        ReviewPlate(dish);
    }

    private PlateEvaluation ReviewPlate(Dictionary<Category, WeightageScoring> dish)
    {
        int counter = 0;

        foreach(var dictionary in dish)
        {
            Debug.Log($"{dictionary.Key} is {dictionary.Value.Review} and {dictionary.Value.Score}");
            if(dictionary.Value.Review == ReviewResponses.Green)
            {
                Debug.Log(dictionary.Key + " is Green");
                counter++;
            }
        }

        if(counter >= 2)
        {
            Debug.Log("Good dish");
            return PlateEvaluation.Good;
        }
        else
        {
            Debug.Log("Bad dish");
            return PlateEvaluation.Bad;
        }
    }
}

public class PyramidCalculator : MonoBehaviour
{
    [SerializeField] private Poster poster;

    private Dictionary<Category, int> recommendedWeightage = new Dictionary<Category, int>()
    {
        {Category.OilsAndFats, 2},
        { Category.Carb, 12},
        { Category.Dairy, 12},
        { Category.Fruit, 12},
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
                Debug.Log("Limit reached");
            }

            trackerText.text = $"{currentAmountServed} / {TargetAmountForPlateServe}";
        }
    }

    public Action OnServePlate;

    private void Start()
    {
        OnServePlate += () => CurrentAmountServed++;
        OnServePlate += () => plateServedTracker.Add(new PlateServed(CurrentWeightage));
        OnServePlate += ResetWeightage;
    }

    #region Pyramid 
    //MAke Action argument to update ReviewResponses and UIs
    public void UpdatePyramidCalculation(Category cat)
    {
        float value = CompareWeightage(cat);

        if(value == 1)
        {
            //Perfect make it green;
            Debug.Log("Perfect");
            CurrentWeightage[cat].Review = ReviewResponses.Green;
            poster.OnUIUpdate?.Invoke(Color.green, cat);
        }
        else if(value < 1)
        {
            //make it gray
            Debug.Log("Need more");
            CurrentWeightage[cat].Review = ReviewResponses.Grey;
            poster.OnUIUpdate?.Invoke(Color.black, cat);
        }
        else
        {
            //make it red
            Debug.Log("Too much");
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

    #endregion


    
}
