using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    private string id;
    public string Id => id;

    private string pw;
    public string Pw => pw;

    private string schoolID;
    public string SchoolID => schoolID;

    private string classID;
    public string ClassID => classID;

    private Dictionary<string, object> userData = new Dictionary<string, object>();
    public Dictionary<string, object> UserData => userData;
    public User(string id, string pw, string schoolID, string classID)
    {
        this.id = id;
        this.pw = pw;
        this.schoolID = schoolID;
        this.classID = classID;

        userData.Add("id", id);
        userData.Add("pw", pw);
        userData.Add("school_ID", schoolID);
        userData.Add("class_ID", classID);
    }
}
