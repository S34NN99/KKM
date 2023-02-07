using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private List<Ingredient> allIngredients;
    private Dictionary<Category, List<Ingredient>> sortedIngredients = new Dictionary<Category, List<Ingredient>>()
    {
        {Category.Dairy, new List<Ingredient>()},
        {Category.Protein, new List<Ingredient>()},
        {Category.Carb, new List<Ingredient>()},
        {Category.Vege, new List<Ingredient>()},
        {Category.Fruit, new List<Ingredient>()},
    };

    //maybe make it into a dict in the future
    [SerializeField] private List<Ingredient> todayMenus;
    public List<Ingredient> TodayMenus => todayMenus;

    private void Awake()
    {
        SortIngredients();
        RandomizeTodayMenu();
    }

    private void SortIngredients()
    {
        foreach(var ingredient in allIngredients)
        {
            sortedIngredients[ingredient.Category].Add(ingredient);
        }
    }

    //Determine which items get to be in the menu here
    private void RandomizeTodayMenu()
    {
        GetIngredient(Category.Carb, 2, ref todayMenus);
        //GetIngredient(Category.Protein, 1, ref todayMenus);
    }

    #region Conditions
    private void GetIngredient(Category cat, int num, ref List<Ingredient> ingredientsListed)
    {
        List<Ingredient> temp = sortedIngredients[cat];

        for(int i = 0; i < num; i++)
        {
            int randomNum = Random.Range(0, temp.Count);
            ingredientsListed.Add(temp[randomNum]);
            temp.RemoveAt(randomNum);
        }
    }

    #endregion

    #region Add Trays To Game Scene



    #endregion




}
