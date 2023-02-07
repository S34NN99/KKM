using TMPro;
using UnityEngine;

public class InspectUIScript : MonoBehaviour
{
    public TextMeshProUGUI FinishedMoreThan3Stars;
    public TextMeshProUGUI NumberOf5tars;
    public TextMeshProUGUI HealthyStudents;
    public TextMeshProUGUI PrincipalRecommendations;
    public TextMeshProUGUI HealthInspector;

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
