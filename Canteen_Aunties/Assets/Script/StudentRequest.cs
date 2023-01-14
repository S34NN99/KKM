using System;
using UnityEngine;

public class StudentRequest : MonoBehaviour
{

    Animator animator => GetComponentInChildren<Animator>();
    public Action OnStudentServed;

    private void Start()
    {
        OnStudentServed += SendInStudent;
    }

    public void SendInStudent()
    {
        animator.SetTrigger("NextStudent");
    }
}
