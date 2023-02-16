using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private Image foodBG;
    [SerializeField] private Image image;
    [SerializeField] private Text category;
    [SerializeField] private Text weightage;
    [SerializeField] private Text additionalInfo;

    [SerializeField] private List<Sprite> foodBGList;

    public void DisplayIngredient(BlackBoardIngredients bbIngredient)
    {
        image.sprite = bbIngredient.Ingredient.TraySprite;
        category.text = bbIngredient.Ingredient.Category.ToString();
        weightage.text = bbIngredient.Ingredient.Weightage.ToString();
        additionalInfo.text = bbIngredient.Ingredient.IngredientName;
        foodBG.sprite = GetBGSprite(bbIngredient.Ingredient.Category);

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(bbIngredient.Ingredient.TraySprite.rect.width, bbIngredient.Ingredient.TraySprite.rect.height);
    }

    private Sprite GetBGSprite(Category category)
    {
        return foodBGList[(int)category - 1] ;
    }
}
