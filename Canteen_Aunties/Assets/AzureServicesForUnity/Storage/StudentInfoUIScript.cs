using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AzureServicesForUnity.Shared;

public class StudentInfoUIScript : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private Text nameText;
    [HideInInspector] public string schoolCode;

    private string studentName;
    public string StudentName
    {
        get { return studentName; }
        set { studentName = value; nameText.text = value; }
    }

    [SerializeField] private User currentUser;
    private InspectUIScript inspect;

    public void InputName(string name)
    {
        nameText.text = name;
    }

    private void Start()
    {
        GetUser();
    }

    public void Inspect()
    {
        inspect = FindObjectOfType<InspectUIScript>();

        TableQuery tq = new TableQuery()
        {
            filter = $"PartitionKey eq '{studentName}'",
            select = "PartitionKey, RowKey, SessionPlayed, NumberOfCompleteHealthyPlateWithDairy," +
            "NumberOfCompleteHealthyPlateWithoutDairy, AverageImprovementOfFullyHealthyPlate," +
            "AverageDurationOfGamePlayPerEntry, AverageDurationToCompleteAHealthyPlateWithDairy," +
            "AverageDurationToCompleteAHealthyPlateWithoutDairy, NumberOfPlatesDiscard, AverageGreenBarsPerPlate"
        };

        TableStorageClient.Instance.QueryTable<Stats>(tq, schoolCode, queryTableResponse =>
        {
            if(queryTableResponse.Status == CallBackResult.Success)
            {
                Debug.Log("Successful");
                inspect.OpenInspect();
                foreach(var item in queryTableResponse.Result)
                {
                    inspect.studentName.text = item.PartitionKey;

                    inspect.sessionPlayed.text = item.SessionPlayed.ToString();
                    inspect.avgDurationOfGamePlay.text = (int)item.AverageDurationOfGamePlayPerEntry + " seconds";
                    inspect.completedHealthyPlateWithDairy.text = item.NumberOfCompleteHealthyPlateWithDairy + "";
                    inspect.completedHealthyPlateWithoutDairy.text = item.NumberOfCompleteHealthyPlateWithoutDairy + "";
                    inspect.avgDurationToCompleteWithoutDairy.text = (int)item.AverageDurationToCompleteAHealthyPlateWithoutDairy + " seconds";
                    inspect.avgDurationToCompleteWithDairy.text = (int)item.AverageDurationToCompleteAHealthyPlateWithDairy + " seconds";
                    inspect.avgImprovementOfHealthyPlate.text = item.AverageImprovementOfFullyHealthyPlate.ToString();
                    inspect.avgGreenBarsPerPlate.text = item.AverageGreenBarsPerPlate.ToString();
                    inspect.numberOfPlatesDiscarded.text = item.NumberOfPlatesDiscard.ToString();
                }
            }
        });   
    }

    public void GetUser()
    {
        TableQuery tq = new TableQuery()
        {
            filter = $"PartitionKey eq '{studentName}'",
            select = "PartitionKey, RowKey, SchoolAndClass"
        };

        Debug.Log("looking for user");
        TableStorageClient.Instance.QueryTable<User>(tq, "users", queryTableResponse =>
        {
            if (queryTableResponse.Status == CallBackResult.Success)
            {
                foreach (var item in queryTableResponse.Result)
                {
                    currentUser = item;
                    Debug.Log("User found");
                }
            }
        });
    }

    public void OpenChangePasswordMenu()
    {
        ChangePasswordUIScript changePW = FindObjectOfType<ChangePasswordUIScript>();

        changePW.OpenTab(currentUser);
    }
}
