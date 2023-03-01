using UnityEngine;
using UnityEngine.UI;

public class InspectUIScript : MonoBehaviour
{
    public Text studentName;
    public Text sessionPlayed;
    public Text avgDurationOfGamePlay;
    public Text completedHealthyPlateWithDairy;
    public Text completedHealthyPlateWithoutDairy;
    public Text avgDurationToCompleteWithoutDairy;
    public Text avgDurationToCompleteWithDairy;
    public Text avgImprovementOfHealthyPlate;
    public Text avgGreenBarsPerPlate;
    public Text numberOfPlatesDiscarded;

    [SerializeField] private GameObject inspectTab;
    public void OpenInspect()
    {
        inspectTab.SetActive(true);
    }

    public void CloseInspect()
    {
        inspectTab.SetActive(false);
    }
}
