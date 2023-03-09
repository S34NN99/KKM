using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AzureServicesForUnity.Shared;

public class ChangePasswordUIScript : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [HideInInspector] public string schoolCode;

    private string studentName;
    public string StudentName
    {
        get { return studentName; }
        set { studentName = value; nameText.text = value; }
    }

    [SerializeField] private GameObject tab;
    [SerializeField] private Text resultText;
    //[SerializeField] private InputField input1;
    //[SerializeField] private InputField input2;
    [SerializeField] private User currentUser;

    public void OpenTab(User user)
    {
        currentUser = user;
        StudentName = currentUser.PartitionKey;
        resultText.text = currentUser.RowKey;
        tab.SetActive(true);
    }

    //public void ChangePassword()
    //{
    //    if (input1.text != input2.text)
    //    {
    //        resultText.text = "Passwords does not match, please try again";
    //        return;
    //    }

    //    //currentUser.RowKey = input1.text;
    //    //currentUser.SchoolAndClass = "S2C2";
    //    TableStorageClient.Instance.UpdateEntity<User>(currentUser, "users", updateEntityResponse =>
    //    {
    //        if (updateEntityResponse.Status == CallBackResult.Success)
    //        {
    //            resultText.text = "Password changed";
    //        }
    //    });
    //}
}
