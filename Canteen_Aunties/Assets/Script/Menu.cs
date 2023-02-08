using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private List<Ingredient> allIngredients;
    public List<Ingredient> AllIngredients => allIngredients;

    private Dictionary<Category, List<Ingredient>> sortedIngredients = new Dictionary<Category, List<Ingredient>>()
    {
        {Category.Dairy, new List<Ingredient>()},
        {Category.Protein, new List<Ingredient>()},
        {Category.Carb, new List<Ingredient>()},
        {Category.Vege, new List<Ingredient>()},
        {Category.Fruit, new List<Ingredient>()},
    };

    [SerializeField] private List<Ingredient> notOnTray;
    public List<Ingredient> NotOnTray => notOnTray;

    //maybe make it into a dict in the future
    [SerializeField] private List<Ingredient> todayMenus = new List<Ingredient>();
    public List<Ingredient> TodayMenus => todayMenus;


    [Header("Tray")]
    [Space(10)]
    [SerializeField] private GameObject trayParent;
    [SerializeField] private GameObject dairyParent;
    [SerializeField] private GameObject carbParent;
    [Range(0,20)]
    [SerializeField] private float spacing;

    private void Awake()
    {
        SortIngredients();
        RandomizeTodayMenu();
        SpawnTrays();
    }

    private void SortIngredients()
    {
        foreach(var ingredient in AllIngredients)
        {
            sortedIngredients[ingredient.Category].Add(ingredient);
        }
    }

    //Determine which items get to be in the menu here
    private void RandomizeTodayMenu()
    {
        GetIngredient(Category.Carb, 2, ref todayMenus);
        GetIngredient(Category.Protein, 1, ref todayMenus);
        GetIngredient(Category.Vege, 1, ref todayMenus);
        GetIngredient(Category.Fruit, 1, ref todayMenus);
        GetIngredient(Category.Dairy, 1, ref todayMenus);

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
    private void SpawnTrays()
    {
        foreach(Ingredient ingredient in TodayMenus)
        {
            if (CheckExcludedIngredient(ingredient, NotOnTray))
                continue;

            GameObject newTray = Instantiate(ingredient.IngredientTray, trayParent.transform);
            newTray.transform.position = new Vector2(trayParent.transform.position.x + (spacing * (trayParent.transform.childCount - 1)), trayParent.transform.position.y);
        }
    }

    bool CheckExcludedIngredient(Ingredient ingredientToCheck, List<Ingredient> excludedIngredients)
    {
        foreach(Ingredient ingredient in excludedIngredients)
        {
            if (ingredientToCheck == ingredient)
            {
                if (ingredient.Category == Category.Dairy)
                {
                    GameObject newTray = Instantiate(ingredient.IngredientTray, dairyParent.transform);
                }
                else
                {
                    GameObject newTray = Instantiate(ingredient.IngredientTray, carbParent.transform);
                }
                return true;
            }
        }
        return false;
    }
    #endregion




}
