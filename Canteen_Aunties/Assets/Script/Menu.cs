using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] private List<GameObject> trayParents;
    [SerializeField] private GameObject trayParentPrefab;
    [SerializeField] private GameObject table;
    [SerializeField] private GameObject dairyParent;
    [SerializeField] private GameObject carbParent;
    [Range(0,20)]
    [SerializeField] private float spacing;

    private int currentTrayPage = 0;

    private void Awake()
    {
        SortIngredients();
        RandomizeTodayMenu();
        SpawnTrays();
        SendOutFirstTray();
    }

    #region Tray Movement
    private void SendOutFirstTray()
    {
        trayParents[0].GetComponent<Animator>().SetTrigger("OnEnterRight");
    }

    public void NextTray(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentTrayPage++;
            if (currentTrayPage >= trayParents.Count)
            {
                currentTrayPage--;
                return;
            }

            trayParents[currentTrayPage].GetComponent<Animator>().SetTrigger("OnEnterRight");
            trayParents[currentTrayPage - 1].GetComponent<Animator>().SetTrigger("OnExitLeft");
        }
    }

    public void PreviousTray(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentTrayPage--;
            if (currentTrayPage < 0)
            {
                currentTrayPage = 0;
                return;
            }

            trayParents[currentTrayPage].GetComponent<Animator>().SetTrigger("OnEnterLeft");
            trayParents[currentTrayPage + 1].GetComponent<Animator>().SetTrigger("OnExitRight");
        }
    }
    #endregion

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
        GetCarbBelowTable(ref todayMenus);
        GetIngredient(Category.Carb, 1, ref todayMenus);
        GetIngredient(Category.Protein, 2, ref todayMenus);
        GetIngredient(Category.Vege, 2, ref todayMenus);
        GetIngredient(Category.Fruit, 2, ref todayMenus);
        GetIngredient(Category.Dairy, 1, ref todayMenus);
        ShuffleMenuList(ref todayMenus);
    }

    #region Conditions
    private void GetIngredient(Category cat, int num, ref List<Ingredient> ingredientsListed)
    {
        List<Ingredient> ingredientList = new List<Ingredient>();

        if (cat.Equals(Category.Carb))
        {
            List<Ingredient> tempList = sortedIngredients[cat];
            foreach(Ingredient ing in tempList)
            {
                bool isInList = false;
                for(int i = 0; i < NotOnTray.Count; i++)
                {
                    if (ing == NotOnTray[i])
                    {
                        isInList = true;
                        break;
                    }
                }

                if (!isInList)
                    ingredientList.Add(ing);
            }
        }
        else
            ingredientList = sortedIngredients[cat];

        for (int i = 0; i < num; i++)
        {
            int randomNum = Random.Range(0, ingredientList.Count);
            ingredientsListed.Add(ingredientList[randomNum]);
            ingredientList.RemoveAt(randomNum);
        }
    }

    private void GetCarbBelowTable(ref List<Ingredient> ingredientsListed)
    {
        List<Ingredient> temp = new List<Ingredient>();

        foreach(Ingredient ingredient in NotOnTray)
        {
            if(ingredient.Category == Category.Carb)
            temp.Add(ingredient);
        }

        int random = Random.Range(0, temp.Count);
        ingredientsListed.Add(temp[random]);
    }

    private void ShuffleMenuList(ref List<Ingredient> ingredientsListed)
    {
        for (int i = 0; i < ingredientsListed.Count; i++)
        {
            var temp = ingredientsListed[i];
            int randomIndex = Random.Range(i, ingredientsListed.Count);
            ingredientsListed[i] = ingredientsListed[randomIndex];
            ingredientsListed[randomIndex] = temp;
        }
    }

    #endregion

    #region Add Trays To Game Scene
    private void SpawnTrays()
    {
        int counter = 0;
        GameObject newTrayParent = null;
        foreach (Ingredient ingredient in TodayMenus)
        {
            if (CheckExcludedIngredient(ingredient, NotOnTray))
                continue;

            if (counter == 0)
            {
                newTrayParent = Instantiate(trayParentPrefab, table.transform);
                trayParents.Add(newTrayParent);
            }

            //Create new prefab object and create it in the parent
            GameObject newTray = Instantiate(ingredient.IngredientTray, newTrayParent.transform);
            newTray.transform.position = new Vector2(newTrayParent.transform.position.x + (spacing * (newTrayParent.transform.childCount - 1)), newTrayParent.transform.position.y);
            counter++;

            if(counter >= 4)
                counter = 0;
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
