using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Category
{
    OilsAndFats, Dairy, Protein, Carb, Vege, Fruit
}

[CreateAssetMenu(fileName = "IngredientData", menuName = "ScriptableObjects/IngredientData", order = 0)]
public class Ingredient : ScriptableObject
{
    [SerializeField] private string ingredientName;
    public string IngredientName => ingredientName;
    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;

    [SerializeField] private Category category;
    public Category Category => category;

    [SerializeField] private bool hasFats;
    public bool HasFats => hasFats;

    [SerializeField] private int weightage;
    public int Weightage => weightage;
}

