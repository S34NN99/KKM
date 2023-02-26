using UnityEngine;
using System;
using UnityEngine.UI;
using AzureServicesForUnity.Shared;
using UnityEngine.SceneManagement;

[Serializable()]
public class User : TableEntity
{
    public User(string partitionKey, string rowKey)
        : base(partitionKey, rowKey) { SplitText(partitionKey); }

    public User() : base() { }

    public Titles Title = Titles.Student;

    public  string SchoolAndClass;

    private void SplitText(string partitionKey)
    {
        string[] s = partitionKey.Split('_');

        if (s.Length < 2)
            return;

        this.SchoolAndClass = s[0];
        this.PartitionKey = s[1];
    }

    public enum Titles
    {
        Student, 
        Teacher
    }

}

public class StorageUIScript : MonoBehaviour
{
    public Text StatusText;
    public InputField customerNameText;
    public InputField passwordText;

    readonly private string tableName = "users";

    public Action OnStudentLogin;
    public Action OnTeacherLogin;
    public Action OnAnomyousLogin;

    public string UserID
    {
        get 
        {
            string[] s = customerNameText.text.Split('_');
            return s[2]; 
        }
    }

    TableQuery tq = new TableQuery()
    {
        //filter = "Age ge 30 and Age le 33", //Age >= 30 && Age <= 33
        select = "PartitionKey, RowKey, SchoolAndClass, Title"
    };

    public void Start()
    {
        Globals.DebugFlag = true;

        if (Globals.DebugFlag)
            Debug.Log("instantiated Azure Services for Unity, version " + Globals.LibraryVersion);

        //select the backend storage type regarding on where your tables are located, either Azure Table Storage or CosmosDB
        //available choices are EndpointStorageType.TableStorage and EndpointStorageType.CosmosDBTableAPI
        
        //TableStorageClient.Instance.EndpointStorageType = EndpointStorageType.TableStorage;

        //your storage account name
        
        //TableStorageClient.Instance.SetAccountName("kindlinginteractive");

        //for Table Storage, fill either one of the below authentication methods
        //for CosmosDB Table API, you should use the AuthenticationToken credential by setting it with your AccountKey

        //TableStorageClient.Instance.AuthenticationToken = "";
        
        //TableStorageClient.Instance.SASToken = "?sv=2021-06-08&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2023-02-01T12:22:52Z&st=2023-01-27T04:22:52Z&spr=https&sig=fTxzAykUYiVGT%2F0FTsq2jzRmCO3NtN80KMWBKU8S70g%3D";
        
        OnStudentLogin += () => StatusText.text = "Student Login Succesful";
        OnStudentLogin += () => SceneManager.LoadScene("MainMenu");

        OnTeacherLogin += () => StatusText.text = "Teacher Login Succesful";
        OnTeacherLogin += () => SceneManager.LoadScene("TeacherMainMenu");

        OnAnomyousLogin += () => SceneManager.LoadScene("MainMenu");
    }

    public void AnomynousLogin()
    {
        TableStorageClient.Instance.CurrentUser = new User();
        OnAnomyousLogin?.Invoke();
    }

    private void ShowError(string error)
    {
        Debug.Log(error);
        StatusText.text = "Error: " + error;
    }

    private bool Verification(User userInput, User dataBaseInput)
    {
        if (userInput.SchoolAndClass != dataBaseInput.SchoolAndClass)
        {
            Debug.Log($"school and class {userInput.SchoolAndClass} user input and {dataBaseInput.SchoolAndClass} database");
            return false;
        }

        if (userInput.PartitionKey != dataBaseInput.PartitionKey)
            return false;

        if (userInput.RowKey != dataBaseInput.RowKey)
            return false;

        return true;
    }

    //Login Function
    public void QueryTableAndLogin()
    {
        User user = new User(customerNameText.text, passwordText.text);

        TableStorageClient.Instance.QueryTable<User>(tq, tableName, queryTableResponse =>
         {
             if (queryTableResponse.Status == CallBackResult.Success)
             {
                 string status = "QueryTable completed";
                 if (Globals.DebugFlag)  Debug.Log(status);
                 foreach (var item in queryTableResponse.Result)
                 {
                     if (Verification(user, item))
                     {
                         //Login here
                         TableStorageClient.Instance.CurrentUser = item;

                         if (item.Title == User.Titles.Student)
                             OnStudentLogin?.Invoke();
                         else
                             OnTeacherLogin?.Invoke();

                         return;
                     }
                 }
                 GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFailedLogin);
             }
             else
             {
                 GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFailedLogin);
                 ShowError(queryTableResponse.Exception.Message);
             }
         });
        StatusText.text = "Loading...";
    }

    public void CreateTable()
    {
        TableStorageClient.Instance.CreateTableIfNotExists(tableName, createTableResponse =>
        {
            if (createTableResponse.Status == CallBackResult.Success)
            {
                string result = "CreateTable completed";
                Debug.Log(result);
                StatusText.text = result;
            }
            //you could also check if CallBackResult.ResourceExists
            else
            {
                ShowError(createTableResponse.Exception.Message);
            }
        });
        StatusText.text = "Loading...";
    }

    public void DeleteTable()
    {
        TableStorageClient.Instance.DeleteTable(tableName, deleteTableResponse =>
        {
            if (deleteTableResponse.Status == CallBackResult.Success)
            {
                string result = "DeleteTable completed";
                Debug.Log(result);
                StatusText.text = result;
            }
            else
            {
                ShowError(deleteTableResponse.Exception.Message);
            }
        });
        StatusText.text = "Loading...";
    }

    public void InsertEntity()
    {
        User user = new User(customerNameText.text, passwordText.text);
        bool userExist = false;

        TableStorageClient.Instance.QueryTable<User>(tq, tableName, queryTableResponse =>
        {
            foreach (var item in queryTableResponse.Result)
            {
                if (Verification(user, item))
                {
                    Debug.Log(string.Format("Item with PartitionKey {0} and RowKey {1}", item.PartitionKey, item.RowKey));
                    //Login here
                    StatusText.text = "User exists";
                    userExist = true;
                    break;
                }
            }

            if (!userExist)
            {
                TableStorageClient.Instance.InsertEntity<User>(user, tableName, insertEntityResponse =>
                {
                    if (insertEntityResponse.Status == CallBackResult.Success)
                    {
                        string result = "InsertEntity completed";
                        Debug.Log(result);
                        StatusText.text = result;
                    }
                    else
                    {
                        ShowError(insertEntityResponse.Exception.Message);
                    }
                });
            }
        });
        StatusText.text = "Loading...";
    }

    public void UpdateEntity()
    {
        User cust = new User()
        {
            PartitionKey = "Gkanatsios23",
            RowKey = "Dimitris23",
        };

        TableStorageClient.Instance.UpdateEntity<User>(cust, tableName, updateEntityResponse =>
        {
            if (updateEntityResponse.Status == CallBackResult.Success)
            {
                string result = "UpdateEntity completed";
                Debug.Log(result);
                StatusText.text = result;
            }
            else
            {
                ShowError(updateEntityResponse.Exception.Message);
            }
        });
        StatusText.text = "Loading...";
    }
}