using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AzureServicesForUnity.Shared;
using System;

[Serializable()]
public class Stats : TableEntity
{
    public int Finished_Service_With_More_Than_3_Stars;
    public int Five_Stars;
    public int Healthy_Students;
    public int Principal_Recommendations;
    public int Health_Inspector_Demerits;


    public int Student_Preferences;
    public int Meal_Requirement;

    public Stats(string partitionKey, string rowKey)
        : base(partitionKey, rowKey) { }

    public Stats() : base()
    {
        PartitionKey = TableStorageClient.Instance.CurrentUser.PartitionKey;
        RowKey = TableStorageClient.Instance.CurrentUser.SchoolAndClass;
    }
}

public class StatisticTracker : MonoBehaviour
{
    private const string finished_Service = "Finished Service With 3 Stars OrMore";
    public string Finished_Service => finished_Service;

    private const string five_Stars = "Number Of 5 Stars";
    public string Five_Stars => five_Stars;

    private const string healthy_Students = "Number Of Healthy Students";
    public string Healthy_Students => healthy_Students;

    private const string student_Preferences = "Number Of Student Preferences";
    public string Student_Preferences => student_Preferences;

    private const string meal_Requirement = "Number Of Meal Requirements";
    public string Meal_Requirement => meal_Requirement;

    private const string one_Star = "One Star";
    public string One_Star => one_Star;

    private const string two_Star = "Two Star";
    public string Two_Star => two_Star;

    private int totalStarsAchieve;
    public int TotalStarsAchieve
    {
        get { return totalStarsAchieve; }
        private set 
        {
            totalStarsAchieve = value;

            if (totalStarsAchieve == 4)
            {
                totalStarsAchieve++;
                Statistics[Five_Stars]++;
            }
        }
    }

    private Dictionary<string, int> statistics = new Dictionary<string, int>()
    {
        {finished_Service, 0},
        {five_Stars, 0},
        {healthy_Students, 0},
        {student_Preferences, 0},
        {meal_Requirement, 0}
    };

    public Dictionary<string, int> Statistics { get { return statistics; } private set { } }

    private Dictionary<string, float> starThreshold = new Dictionary<string, float>()
    {
        {two_Star, 0.9f},
        {one_Star, 0.5f}
    };

    [SerializeField] private Stars stars;
    [SerializeField] private ReviewsSO reviewSO;
    [Space(10)]
    [SerializeField] private GameObject starPlaceholders;
    [SerializeField] private TextMeshProUGUI reviewText;
    [SerializeField] private TextMeshProUGUI reviewText2;

    public void AddToStatisticDictionary(string name, int number)
    {
        Statistics[name] += number;
        Debug.Log($"{name} has a total of {Statistics[name]} good dishes");
    }

    #region Star Calculation
    public void PeformStarCalculations(int totalPlateServed)
    {
        TotalStarsAchieve += StudentPreferencesCalculation(totalPlateServed);
        TotalStarsAchieve += MealRequirementCalculation(totalPlateServed);

        UpdateStarUI();
        reviewText.text = reviewSO.RandomizeReview(reviewSO.FiveStarReviews);
        reviewText2.text = reviewSO.RandomizeReview(reviewSO.FiveStarReviews);

        Debug.Log($"{TotalStarsAchieve} is total stars");
    }

    private int StudentPreferencesCalculation(int totalPlateServed)
    {
        int amountOfGoodDishes = Statistics[Student_Preferences];

        float percentage = (float)(amountOfGoodDishes) / (float)totalPlateServed;
        Debug.Log($"{percentage} is the {Student_Preferences}");

        if (percentage > starThreshold[Two_Star])
            return 2;
        else if (percentage > starThreshold[One_Star])
            return 1;

        return 0;
    }

    private int MealRequirementCalculation(int totalPlateServed)
    {
        int amountOfGoodDishes = Statistics[Meal_Requirement];

        float percentage = (float) (amountOfGoodDishes) / (float) totalPlateServed;
        Debug.Log($"{percentage} is the {meal_Requirement}");

        if (percentage > starThreshold[Two_Star])
            return 2;
        else if (percentage > starThreshold[One_Star])
            return 1;

        return 0;
    }

    private void UpdateStarUI()
    {
        for(int i = 0; i < TotalStarsAchieve; i++)
        {
            starPlaceholders.transform.GetChild(i).GetComponent<Image>().sprite = stars.StarYes;
        }
    }
    #endregion

    #region Database 
    public void UpdateStatsToDatabase()
    {
        TableStorageClient client = FindObjectOfType<TableStorageClient>();

        if (client.CurrentUser.PartitionKey == null)
            return;

        Stats stats = new Stats();
        ConvertStatsToTableEntity(stats, statistics);

        client.UpdateEntity(stats, client.CurrentUser.SchoolAndClass, updateEntityResponse =>
        {
            if (updateEntityResponse.Status == CallBackResult.Success)
            {
                string result = "UpdateEntity completed";
                Debug.Log(result);
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }

    private void ConvertStatsToTableEntity(Stats stats, Dictionary<string, int> dict)
    {
        stats.Finished_Service_With_More_Than_3_Stars = dict[Finished_Service];
        stats.Five_Stars = dict[Five_Stars];
        stats.Healthy_Students = dict[Healthy_Students];
        stats.Meal_Requirement = dict[Meal_Requirement];
        stats.Student_Preferences = dict[Student_Preferences];
    }
    #endregion
}
