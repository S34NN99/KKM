using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AzureServicesForUnity.Shared;

public class StudentInfoUIScript : MonoBehaviour
{
    [Header("UIs")]
    public TextMeshProUGUI schoolText;
    public TextMeshProUGUI nameText;

    [SerializeField] private InspectUIScript inspect;

    public void Inspect()
    {
        inspect = FindObjectOfType<InspectUIScript>();

        TableQuery tq = new TableQuery()
        {
            filter = $"PartitionKey eq '{nameText.text}'",
            select = "PartitionKey, Finished_Service, Five_Stars, Healthy_Students, Meal_Requirement, Student_Preferences",
        };

        TableStorageClient.Instance.QueryTable<Stats>(tq, schoolText.text, queryTableResponse =>
        {
            if(queryTableResponse.Status == CallBackResult.Success)
            {
                Debug.Log("Successful");
                inspect.OpenInspect();
                foreach(var item in queryTableResponse.Result)
                {
                    inspect.FinishedMoreThan3Stars.text = item.Finished_Service_With_More_Than_3_Stars.ToString();
                    inspect.NumberOf5tars.text = item.Five_Stars.ToString();
                    inspect.HealthyStudents.text = item.Healthy_Students.ToString();
                    inspect.PrincipalRecommendations.text = item.Principal_Recommendations.ToString();
                    inspect.HealthInspector.text = item.Health_Inspector_Demerits.ToString();
                }
            }
            else
            {
                Debug.Log("Not Successful");
            }

        });   
    }
}
