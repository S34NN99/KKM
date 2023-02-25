using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StudentRequestUpdate : MonoBehaviour
{
    [SerializeField] private List<StudentRequest> students;
    [SerializeField] private Plate plate;

    [SerializeField] private List<int> orderList;

    private void Start()
    {
        InitilizeOrder();
        ShuffleList();
        ShowNextStudent();
    }

    public void ShowNextStudent()
    {
        int temp = orderList[0];
        students[temp].gameObject.SetActive(true);
        Image handImage = students[temp].transform.Find("MainStudent/DairyOnHand").GetComponent<Image>();
        plate.ChangeStudentRequest(students[temp], handImage);
        orderList.RemoveAt(0);

        if (orderList.Count <= 0)
            InitilizeOrder();
    }

    private void ShuffleList()
    {
        for (int i = 0; i < orderList.Count; i++)
        {
            int temp = orderList[i];
            int randomIndex = Random.Range(i, orderList.Count);
            orderList[i] = orderList[randomIndex];
            orderList[randomIndex] = temp;
        }
    }

    private void InitilizeOrder()
    {
        orderList = new List<int>();
        for (int i = 0; i < students.Count; i++)
        {
            orderList.Add(i);
        }
    }
}
