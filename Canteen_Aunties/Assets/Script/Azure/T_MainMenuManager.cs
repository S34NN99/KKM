﻿using TMPro;
using UnityEngine;
using System;
using AzureServicesForUnity.Shared;
using UnityEngine.SceneManagement;

public class T_MainMenuManager : MonoBehaviour
{
    [Header("Getting Student Info")]
    [SerializeField] private GameObject studentInfoPrefab;
    [SerializeField] private TableStorageClient azureScript;
    [SerializeField] private GameObject toBeParent;
    [SerializeField] private TMP_InputField codeToBeSearch;

    private TableStorageClient client;
    public Action<User> DisplayUser;

    private void Start()
    {
        DisplayUser += (user) =>
        {
            GameObject newGo = Instantiate(studentInfoPrefab, toBeParent.transform);
            StudentInfoUIScript studentUIscript = newGo.GetComponent<StudentInfoUIScript>();

            studentUIscript.schoolText.text = user.RowKey;
            studentUIscript.nameText.text = user.PartitionKey;
        };

        client = FindObjectOfType<TableStorageClient>();
        GetStudentData();
    }

    public void GetStudentData()
    {
        Clear();
        TableQuery tq = new TableQuery()
        {
            select = "PartitionKey, RowKey, SchoolAndClass"
        };

        //Insert inputfield here and make it search the class

        //TableStorageClient.Instance.QueryTable<User>(tq, codeToBeSearch.text, queryTableResponse =>
        TableStorageClient.Instance.QueryTable<User>(tq, client.CurrentUser.SchoolAndClass, queryTableResponse =>
        {
            if (queryTableResponse.Status == CallBackResult.Success)
            {
                string status = "QueryTable completed";
                if (Globals.DebugFlag) Debug.Log(status);
                foreach (var item in queryTableResponse.Result)
                {
                    Debug.Log(string.Format("Item with PartitionKey {0} and RowKey {1}", item.PartitionKey, item.RowKey));
                    DisplayUser?.Invoke(item);
                }
            }
        });
    }

    public void Clear()
    {
        foreach(Transform go in toBeParent.transform)
        {
            Destroy(go.gameObject);
        }
    }

    public void Logout()
    {
        SceneManager.LoadScene("LandingScene");
        TableStorageClient.Instance.CurrentUser = null;
    }


}
