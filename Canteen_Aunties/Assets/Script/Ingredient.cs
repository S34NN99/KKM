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
    [SerializeField] private Translation ingredientName;
    public Translation IngredientName => ingredientName;

    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;

    [SerializeField] private Category category;
    public Category Category => category;

    [SerializeField] private bool hasFats;
    public bool HasFats => hasFats;

    [SerializeField] private string additionalInfo;
    public string AdditionalInfo => additionalInfo;

    [SerializeField] private int weightage;
    public int Weightage => weightage;

    [SerializeField] private int portionSize;
    public int PortionSize => portionSize;

    [SerializeField] private GameObject ingredientTray;
    public GameObject IngredientTray => ingredientTray;

    [SerializeField] private Sprite traySprite;
    public Sprite TraySprite => traySprite;

    [SerializeField] private string soundEffect;
    public string SoundEffect => soundEffect;
}

