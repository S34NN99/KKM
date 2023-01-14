using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Timer : MonoBehaviour
{
    [SerializeField] private float startTimeInSeconds;
    public float StartTimeInSeconds => startTimeInSeconds;
    [SerializeField] private float currentTime;
    [SerializeField] private Image clockUI;

    private void Start()
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
    }
    //rotate around localrotation z axis
    void UpdateUI(float time)
    {
        transform.localRotation = Quaternion.Euler(0, 0, time);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Timer))]
public class Timer_Editor : Editor
{

}
#endif
