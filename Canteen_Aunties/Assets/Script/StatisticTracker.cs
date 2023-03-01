using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AzureServicesForUnity.Shared;
using System;

[Serializable]
public class Stats : TableEntity
{
    public int SessionPlayed;
    public int NumberOfCompleteHealthyPlateWithDairy;
    public int NumberOfCompleteHealthyPlateWithoutDairy;
    public float AverageImprovementOfFullyHealthyPlate;
    public float AverageDurationOfGamePlayPerEntry;
    public float AverageDurationToCompleteAHealthyPlateWithDairy;
    public float AverageDurationToCompleteAHealthyPlateWithoutDairy;
    public int NumberOfPlatesDiscard;
    public float AverageGreenBarsPerPlate;

    //public int Finished_Service_With_More_Than_3_Stars;
    //public int Five_Stars;
    //public int Healthy_Students;
    //public int Principal_Recommendations;
    //public int Health_Inspector_Demerits;

    //public int Student_Preferences;
    //public int Meal_Requirement;

    public Stats(string partitionKey, string rowKey)
        : base(partitionKey, rowKey) { }

    public Stats() : base()
    {
        if (TableStorageClient.Instance == null)
            return;

        PartitionKey = TableStorageClient.Instance.CurrentUser.PartitionKey;
        RowKey = TableStorageClient.Instance.CurrentUser.SchoolAndClass;
    }
}

public class StatisticTracker : MonoBehaviour
{
    private const string sessionPlayed = "Session Played";
    public string SessionPlayed => sessionPlayed;

    private const string numberOfCompleteHealtyPlateWithDairy = "Number Of Complete Healty Plate With Dairy";
    public string NumberOfCompleteHealtyPlateWithDairy => numberOfCompleteHealtyPlateWithDairy;

    private const string numberOfCompleteHealtyPlateWithoutDairy = "Number Of Complete Healty Plate Without Dairy";
    public string NumberOfCompleteHealtyPlateWithoutDairy => numberOfCompleteHealtyPlateWithoutDairy;

    private const string averageImprovementOfFullyHealthyPlate = "Average Improvement Of Fully Healthy Plate";
    public string AverageImprovementOfFullyHealthyPlate => averageImprovementOfFullyHealthyPlate;

    private const string averageDurationOfGamePlayPerEntry = "Average Duration Of GamePlay Per Entry";
    public string AverageDurationOfGamePlayPerEntry => averageDurationOfGamePlayPerEntry;

    private const string averageDurationToCompleteAHealthyPlateWithDairy = "Average Duration To Complete A Healthy Plate With Dairy";
    public string AverageDurationToCompleteAHealthyPlateWithDairy => averageDurationToCompleteAHealthyPlateWithDairy;

    private const string averageDurationToCompleteAHealthyPlateWithoutDairy = "Average Duration To Complete A Healthy Plate Without Dairy";
    public string AverageDurationToCompleteAHealthyPlateWithoutDairy => averageDurationToCompleteAHealthyPlateWithoutDairy;

    private const string numberOfPlatesDiscard = "Number Of Plates Discard";
    public string NumberOfPlatesDiscard => numberOfPlatesDiscard;

    private const string averageGreenBarsPerPlate = "Average Green Bars Per Plate";
    public string AverageGreenBarsPerPlate => averageGreenBarsPerPlate;

    //private const string finished_Service = "Finished Service With 3 Stars OrMore";
    //public string Finished_Service => finished_Service;

    //private const string five_Stars = "Number Of 5 Stars";
    //public string Five_Stars => five_Stars;

    //Not recorded in Azure Database;
    private const string healthy_Students = "Number Of Healthy Students";
    public string Healthy_Students => healthy_Students;

    private const string student_Preferences = "Number Of Student Preferences";
    public string Student_Preferences => student_Preferences;

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
            }
        }
    }

    private Dictionary<string, float> statistics = new Dictionary<string, float>()
    {
        {sessionPlayed, 0},
        {numberOfCompleteHealtyPlateWithDairy, 0},
        {numberOfCompleteHealtyPlateWithoutDairy, 0},
        {averageImprovementOfFullyHealthyPlate, 0},
        {averageDurationOfGamePlayPerEntry, 0},
        {averageDurationToCompleteAHealthyPlateWithDairy, 0},
        {averageDurationToCompleteAHealthyPlateWithoutDairy, 0},
        {numberOfPlatesDiscard, 0},
        {averageGreenBarsPerPlate, 0},
        //Not recorded in azure database
        {healthy_Students, 0},
        {student_Preferences, 0}
    };

    public Dictionary<string, float> Statistics { get { return statistics; } private set { } }

    private Dictionary<string, float> starThreshold = new Dictionary<string, float>()
    {
        {two_Star, 0.8f},
        {one_Star, 0.5f}
    };

    [SerializeField] private Plate plate; 
    [SerializeField] private Stars stars;
    [SerializeField] private ReviewsSO reviewSO;
    [Space(10)]
    [SerializeField] private GameObject starPlaceholders;
    [SerializeField] private TextMeshProUGUI reviewText;
    [SerializeField] private TextMeshProUGUI reviewText2;

    public Action<Stats> OnGetStats;


    [SerializeField] private Stats CurrentStats;
    [SerializeField] private float levelTimer = 0;
    [HideInInspector] public bool startRecordTime;

    private void Start()
    {
        OnGetStats += (user) =>
        {
            CurrentStats.PartitionKey = TableStorageClient.Instance.CurrentUser.PartitionKey;
            CurrentStats.RowKey= TableStorageClient.Instance.CurrentUser.SchoolAndClass;

            CurrentStats.SessionPlayed = user.SessionPlayed;
            CurrentStats.NumberOfCompleteHealthyPlateWithDairy = user.NumberOfCompleteHealthyPlateWithDairy;
            CurrentStats.NumberOfCompleteHealthyPlateWithoutDairy = user.NumberOfCompleteHealthyPlateWithoutDairy;
            CurrentStats.AverageImprovementOfFullyHealthyPlate = user.AverageImprovementOfFullyHealthyPlate;
            CurrentStats.AverageDurationOfGamePlayPerEntry = user.AverageDurationOfGamePlayPerEntry;
            CurrentStats.AverageDurationToCompleteAHealthyPlateWithDairy = user.AverageDurationToCompleteAHealthyPlateWithDairy;
            CurrentStats.AverageDurationToCompleteAHealthyPlateWithoutDairy = user.AverageDurationToCompleteAHealthyPlateWithoutDairy;
            CurrentStats.NumberOfPlatesDiscard = user.NumberOfPlatesDiscard;
            CurrentStats.AverageGreenBarsPerPlate = user.AverageGreenBarsPerPlate;
        };

        CurrentStats = new Stats();
        GetStudentStats();
    }

    private void Update()
    {
        if (startRecordTime)
        {
            levelTimer += Time.deltaTime;
        }
    }

    public void RecordTime(bool power)
    {
        startRecordTime = power;
        plate.startRecordTimeForPlate = power;
    }

    private void GetStudentStats()
    {
        TableQuery tq = new TableQuery()
        {
            select = "PartitionKey, RowKey, SessionPlayed, NumberOfCompleteHealtyPlateWithDairy," +
            "NumberOfCompleteHealtyPlateWithoutDairy, AverageImprovementOfFullyHealthyPlate," +
            "AverageDurationOfGamePlayPerEntry, AverageDurationToCompleteAHealthyPlateWithDairy," +
            "AverageDurationToCompleteAHealthyPlateWithoutDairy, NumberOfPlatesDiscard, AverageGreenBarsPerPlate"
        };

        TableStorageClient.Instance.QueryTable<Stats>(tq, TableStorageClient.Instance.CurrentUser.SchoolAndClass, queryTableResponse =>
        {
            if(queryTableResponse.Status == CallBackResult.Success)
            {
                foreach (var item in queryTableResponse.Result)
                {
                    if(item.PartitionKey == TableStorageClient.Instance.CurrentUser.PartitionKey)
                    {
                        Debug.Log("User found");
                        OnGetStats?.Invoke(item);
                        return;
                    }

                }
                Debug.Log("User not found");
            }
        });
    }


    public void AddToStatisticDictionary(string name, float number)
    {
        Statistics[name] += number;
    }

    #region Star Calculation
    public void PeformStarCalculations(int totalPlateServed)
    {
        TotalStarsAchieve += StudentPreferencesCalculation(totalPlateServed);
        TotalStarsAchieve += MealRequirementCalculation(totalPlateServed);

        UpdateStarUI();
        reviewText.text = reviewSO.RandomizeReview(TotalStarsAchieve);
        reviewText2.text = reviewSO.RandomizeReview(TotalStarsAchieve);

        Debug.Log($"{TotalStarsAchieve} is total stars");
    }

    private int StudentPreferencesCalculation(int totalPlateServed)
    {
        int amountOfGoodDishes = (int)Statistics[Student_Preferences];

        float percentage = (float)(amountOfGoodDishes) / (float)totalPlateServed;
        Debug.Log($"{percentage} is the {Student_Preferences}");

        if (percentage >= starThreshold[Two_Star])
            return 2;
        else if (percentage >= starThreshold[One_Star])
            return 1;

        return 0;
    }

    private int MealRequirementCalculation(int totalPlateServed)
    {
        int amountOfGoodDishes = (int)Statistics[Healthy_Students];

        float percentage = (float) (amountOfGoodDishes) / (float) totalPlateServed;
        Debug.Log($"{percentage} is the {Healthy_Students}");

        if (percentage >= starThreshold[Two_Star])
            return 2;
        else if (percentage >= starThreshold[One_Star])
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

        ConvertStatsToTableEntity(CurrentStats, statistics);

        client.UpdateEntity(CurrentStats, client.CurrentUser.SchoolAndClass, updateEntityResponse =>
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

    private void ConvertStatsToTableEntity(Stats stats, Dictionary<string, float> dict)
    {
        stats.SessionPlayed += (int)dict[SessionPlayed];
        stats.NumberOfCompleteHealthyPlateWithDairy += (int)dict[NumberOfCompleteHealtyPlateWithDairy];
        stats.NumberOfCompleteHealthyPlateWithoutDairy += (int)dict[NumberOfCompleteHealtyPlateWithoutDairy];
        stats.AverageImprovementOfFullyHealthyPlate = (int)(dict[AverageImprovementOfFullyHealthyPlate] + stats.AverageImprovementOfFullyHealthyPlate) / stats.SessionPlayed;
        stats.AverageDurationOfGamePlayPerEntry = (int)(dict[AverageDurationOfGamePlayPerEntry] + levelTimer) / stats.SessionPlayed;
        stats.NumberOfPlatesDiscard += (int)dict[NumberOfPlatesDiscard];
        stats.AverageDurationToCompleteAHealthyPlateWithDairy = (int)(dict[AverageDurationToCompleteAHealthyPlateWithDairy] + stats.AverageDurationToCompleteAHealthyPlateWithDairy) / stats.NumberOfCompleteHealthyPlateWithDairy;
        stats.AverageDurationToCompleteAHealthyPlateWithoutDairy = (int)(dict[AverageDurationToCompleteAHealthyPlateWithoutDairy] + stats.NumberOfCompleteHealthyPlateWithoutDairy) / stats.NumberOfCompleteHealthyPlateWithoutDairy;
        stats.AverageGreenBarsPerPlate = (dict[AverageGreenBarsPerPlate] + stats.AverageGreenBarsPerPlate) / (stats.SessionPlayed * FindObjectOfType<PyramidCalculator>().TargetAmountForPlateServe);
    }
    #endregion
}
