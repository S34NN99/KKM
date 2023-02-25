using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTimeInSeconds;
    public float StartTimeInSeconds => startTimeInSeconds;
    [SerializeField] private PyramidCalculator pyramidCal;
    [SerializeField] private float currentTime;
    [SerializeField] private Image clockUI;

    private bool GameEnd;
    private float angle;

    private void Awake()
    {
        currentTime = StartTimeInSeconds;
    }

    private void Update()
    {
        if (currentTime >= 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateUI(currentTime);
        }
        else
        {
            if (!GameEnd)
            {
                pyramidCal.OnGameEnd?.Invoke();
                GameEnd = true;
            }
        }
    }

    //rotate around localrotation z axis
    void UpdateUI(float time)
    {
        angle = 360/(StartTimeInSeconds/time);
        clockUI.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, angle, currentTime));
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Timer))]
public class Timer_Editor : Editor
{

}
#endif
