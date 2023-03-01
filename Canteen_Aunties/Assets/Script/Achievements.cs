using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AzureServicesForUnity.Shared;

public class AchievementsStats : TableEntity
{
    public bool CompletedGame;
    public bool Serve10PerfectPlate;
    public bool DiscardLessThan3InALevel;
    public bool CompleteGameUnder20Seconds;
    public bool Gotten5StarsInASingleLevel;
    public bool SatisfiedEveryStudentDemand;
    public bool PlayedInENGAndBM;


}

public class Achievements : MonoBehaviour
{
    
}
