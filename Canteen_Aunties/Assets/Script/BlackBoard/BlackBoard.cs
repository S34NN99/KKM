using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBoard : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text category;
    [SerializeField] private Text weightage;
    [SerializeField] private Text additionalInfo;

    public void DisplayIngredient(BlackBoardIngredients bbIngredient)
    {
        image.sprite = bbIngredient.Ingredient.Sprite;
        category.text = bbIngredient.Ingredient.Category.ToString();
        weightage.text = bbIngredient.Ingredient.Weightage.ToString();
        additionalInfo.text = bbIngredient.Ingredient.IngredientName;

        image.GetComponent<RectTransform>().sizeDelta = new Vector2(bbIngredient.Ingredient.Sprite.rect.width, bbIngredient.Ingredient.Sprite.rect.height);
    }
}
