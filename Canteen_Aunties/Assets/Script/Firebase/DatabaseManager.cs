//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;
//using System.Threading.Tasks;

//public class DatabaseManager : MonoBehaviour
//{
//    public static DatabaseManager instance;

//    [SerializeField] private Text idText, pwText, resultText;
//    public string IdText => idText.text;
//    public string PwText => pwText.text;

//    private User currentUser;
//    public User CurrentUser => currentUser;

//    private Score score = new Score();
//    public Score Score => score;

//    private DatabaseReference dbReference;

//    private const string UserPath = "users";
//    private const string OnFailedLoginText = "Invalid ID or Password.";
//    private const string OnFailedRegisterText = "Invalid school or class code/User exists.";
//    private const string OnSuccessfulRegisterText = "Successfully registered";
   
//    public Action<string> DisplayResultText;
//    public Action OnLoginSuccessful;
//    public Action OnScoreUpdate;

//    private void Awake()
//    {
//        if (instance != null && instance != this)
//            Destroy(this);
//        else
//            instance = this;

//        DontDestroyOnLoad(this.gameObject);
//    }

//    void Start()
//    {
//        OnLoginSuccessful += () => currentUser = new User(IdText, PwText, GetCode(IdText, 0), GetCode(IdText, 1));
//        OnLoginSuccessful += LoginSuccessful;
//        DisplayResultText += (string s) => resultText.text = s;

//        OnScoreUpdate += WriteNewScore;
//        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
//    }

//    private void Update()
//    {
//        if(Input.GetButtonDown("Testing"))
//        {
//            OnScoreUpdate?.Invoke();
//        }
//    }

//    #region Login & Register

//    public void Login()
//    {
//        StartCoroutine(LoginWaitASync());
//    }

//    public void Register()
//    {
//        StartCoroutine(RegisterWaitASync());
//    }

//    public IEnumerator RegisterWaitASync()
//    {
//        User newUser = new User(IdText, PwText, GetCode(IdText,0), GetCode(IdText, 1));
//        string json = JsonUtility.ToJson(newUser);
//        bool isSchoolExist = false;

//        var findSchool = dbReference.GetValueAsync().ContinueWith(t =>
//        {
//            if (CheckForSchool(t, newUser.SchoolID))
//            {
//                isSchoolExist = true;
//            }
//        });

//        yield return new WaitUntil(predicate: () => findSchool.IsCompleted);

//        if (isSchoolExist)
//        {
//            var saving = dbReference.Child(newUser.SchoolID).Child(UserPath).Child(newUser.Id).GetValueAsync();

//            yield return new WaitUntil(predicate: () => saving.IsCompleted);

//            DataSnapshot snapshot = saving.Result;

//            if (snapshot.Exists)
//                DisplayResultText?.Invoke(OnFailedRegisterText);
//            else
//            {
//                Dictionary<string, object> newUserData = newUser.UserData;
//                Dictionary<string, object> saveUserData = new Dictionary<string, object>();
//                saveUserData["/" + newUser.SchoolID + "/" + UserPath + "/" + newUser.Id] = newUserData;
//                dbReference.UpdateChildrenAsync(saveUserData);
//                DisplayResultText?.Invoke(OnSuccessfulRegisterText);
//            }
//        }
//        else
//        {
//            DisplayResultText?.Invoke(OnFailedRegisterText);
//        }

//    }

//    private IEnumerator LoginWaitASync()
//    {
//        bool successLogin = false;
//        string schoolCode = null;
        
//        //Check if school is available
//        var findSchool = dbReference.GetValueAsync().ContinueWith(t =>
//        {
//            var tempCode = GetCode(IdText, 0);
//            if (CheckForSchool(t, tempCode))
//            {
//                schoolCode = tempCode;
//            }
//        });

//        yield return new WaitUntil(predicate: () => findSchool.IsCompleted);

//        //Check if student exists
//        if (schoolCode != null)
//        {
//            var userData = dbReference.Child(schoolCode).Child(UserPath).Child(IdText).GetValueAsync().ContinueWith(t =>
//            {
//                successLogin = CheckForUser(t);
//            });

//            yield return new WaitUntil(predicate: () => userData.IsCompleted);

//            if (successLogin)
//                OnLoginSuccessful?.Invoke();
//            else
//                DisplayResultText?.Invoke(OnFailedLoginText);
//        }
//    }

//    private void LoginSuccessful()
//    {
//        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
//    }
//    #endregion

//    #region Scoring
//    public void WriteNewScore()
//    {
//        Debug.Log(CurrentUser.Id + " " + CurrentUser.SchoolID);
//        Dictionary<string, object> entry = Score.IngredientTracker;

//        Dictionary<string, object> childUpdate = new Dictionary<string, object>();
//        childUpdate["/" + CurrentUser.SchoolID + "/scores/" + CurrentUser.Id] = entry;

//        dbReference.UpdateChildrenAsync(childUpdate);
//    }

//    #endregion

//    #region Check User & Tag
//    private string GetCode(string text, int num)
//    {
//        string[] stringSplit = text.Split('_');
//        return stringSplit[num];
//    }

//    private bool CheckForSchool(Task<DataSnapshot> t, string schoolCode)
//    {
//        DataSnapshot snapshot = t.Result;

//        foreach (DataSnapshot s in snapshot.Children)
//        {
//            if (s.Key.Equals(schoolCode))
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    private bool CheckForUser(Task<DataSnapshot> t)
//    {
//        DataSnapshot snapshot = t.Result;
//        bool verify = false;

//        if (snapshot.Exists)
//        {
//            if (snapshot.Child("pw").Value.ToString() == PwText)
//                verify = true;
//        }

//        return verify;
//    }
//    #endregion
//}
