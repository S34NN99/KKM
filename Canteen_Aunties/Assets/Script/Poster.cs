using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poster : MonoBehaviour
{
    [SerializeField] private List<Image> pyramidColumns;
    [SerializeField] private Color defaultColor;
    public Action<Color, Category> OnUIUpdate;
    public Action OnUIReset;
     
    private void Start()
    {
        OnUIUpdate += (Color color, Category cat) => pyramidColumns[(int)cat].color = color;
        OnUIReset += () =>
        {
            foreach(Image image in pyramidColumns)
            {
                image.color = defaultColor;
            }
        };
    }
}
