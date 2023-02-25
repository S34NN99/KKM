using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private Text foodName;
    [SerializeField] private Image foodBG;
    [SerializeField] private Image foodBGPostIt;
    [SerializeField] private Image image;
    [SerializeField] private Text category;
    [SerializeField] private Text weightage;
    [SerializeField] private Text additionalInfo;

    [SerializeField] private List<Sprite> foodBGList;
    [SerializeField] private List<Sprite> foodBGPostItList;

    public void DisplayIngredient(BlackBoardIngredients bbIngredient)
    {
        foodName.text = bbIngredient.Ingredient.IngredientName;
        image.sprite = bbIngredient.Ingredient.TraySprite;
        category.text = bbIngredient.Ingredient.Category.ToString();
        weightage.text = bbIngredient.Ingredient.Weightage.ToString();
        additionalInfo.text = bbIngredient.Ingredient.AdditionalInfo;
        foodBG.sprite = GetBGSprite(foodBGList, bbIngredient.Ingredient.Category);
        foodBGPostIt.sprite = GetBGSprite(foodBGPostItList, bbIngredient.Ingredient.Category);

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(bbIngredient.Ingredient.TraySprite.rect.width, bbIngredient.Ingredient.TraySprite.rect.height);
    }

    private Sprite GetBGSprite(List<Sprite> list,Category category)
    {
        return list[(int)category - 1] ;
    }
}
