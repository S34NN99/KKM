using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BlackBoardInfo
{
    public Category category;
    public string foodGroupENG;
    [TextArea()]
    public string functionOfFoodENG;

    [Space()]
    public string foodGroupBM;
    [TextArea()]
    public string functionOfFoodBM;
}

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private Text foodName;
    [SerializeField] private Image foodBG;
    [SerializeField] private Image foodBGPostIt;
    [SerializeField] private Image image;
    [SerializeField] private Text category;
    [SerializeField] private Text function;
    [SerializeField] private Text weightage;
    [SerializeField] private Text additionalInfo;

    [SerializeField] private List<Sprite> foodBGList;
    [SerializeField] private List<Sprite> foodBGPostItList;

    public List<BlackBoardInfo> info;

    public void DisplayIngredient(BlackBoardIngredients bbIngredient)
    {
        GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnButtonPressed);
        CheckIfCarbIngredient(bbIngredient.Ingredient);
        WriteInfoAndFunction(category, function, bbIngredient.Ingredient.Category);

        foodName.text = !FindObjectOfType<TranslationManager>().IsPlayedInBM ? bbIngredient.Ingredient.IngredientName.EnglishText : bbIngredient.Ingredient.IngredientName.MalayText;
        image.sprite = bbIngredient.Ingredient.TraySprite;
        //category.text = bbIngredient.Ingredient.Category.ToString();
        weightage.text = "x" + bbIngredient.Ingredient.PortionSize.ToString();
        additionalInfo.text = !FindObjectOfType<TranslationManager>().IsPlayedInBM ? bbIngredient.Ingredient.AddtionalInfoSO.EnglishText : bbIngredient.Ingredient.AddtionalInfoSO.MalayText;
        //additionalInfo.text = bbIngredient.Ingredient.AdditionalInfo;
        foodBG.sprite = GetBGSprite(foodBGList, bbIngredient.Ingredient.Category);
        foodBGPostIt.sprite = GetBGSprite(foodBGPostItList, bbIngredient.Ingredient.Category);

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(bbIngredient.Ingredient.TraySprite.rect.width, bbIngredient.Ingredient.TraySprite.rect.height);
    }

    private void WriteInfoAndFunction(Text category, Text function, Category cat)
    {
        foreach (BlackBoardInfo bbinfo in info)
        {
            if (bbinfo.category == cat)
            {
                if (!FindObjectOfType<TranslationManager>().IsPlayedInBM)
                {
                    category.text = bbinfo.foodGroupENG;
                    function.text = bbinfo.functionOfFoodENG;
                }
                else
                {
                    category.text = bbinfo.foodGroupBM;
                    function.text = bbinfo.functionOfFoodBM;
                }
                return;
            }
        }
    }

private Sprite GetBGSprite(List<Sprite> list, Category category)
{
    return list[(int)category - 1];
}

private void CheckIfCarbIngredient(Ingredient ingredient)
{
    image.transform.localScale = new Vector3(1, 1, 1);

    if (ingredient.Category != Category.Carb)
        return;

    if (ingredient.IngredientName.EnglishText == "BREAD")
        return;

    image.transform.localScale = new Vector3(0.5f, 0.5f, 1);
}
}
