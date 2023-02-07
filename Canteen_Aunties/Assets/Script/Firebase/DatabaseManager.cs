using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    public Action OnScoreUpdate;

    private void Awake()
    {

        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        OnScoreUpdate += WriteNewScore;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Testing"))
        {
            OnScoreUpdate?.Invoke();
        }
    }

    public void WriteNewScore()
    {
        //Dictionary<string, object> entry = Score.IngredientTracker;
        //Dictionary<string, object> childUpdate = new Dictionary<string, object>();

    }
}
