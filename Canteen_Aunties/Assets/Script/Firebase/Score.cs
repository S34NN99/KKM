using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    private int numberOfFoodPlated;
    public int NumberOfFoodPlated => numberOfFoodPlated;

    private Dictionary<string, object> ingredientTracker = new Dictionary<string, object>();
    public Dictionary<string, object> IngredientTracker => ingredientTracker;

    public Score()
    {
        Initialize();
    }

    public void Initialize()
    {
        for (int i = 0; i < Enum.GetValues(typeof(Category)).Length; i++)
        {
            ingredientTracker.Add(Enum.GetName(typeof(Category), i), 0);
        }
    }

    public void AddScore(Ingredient ID)
    {
        ingredientTracker.TryGetValue(ID.Category.ToString(), out object tempScore);
        ingredientTracker[ID.Category.ToString()] = (int)tempScore + 1;
    }
}
