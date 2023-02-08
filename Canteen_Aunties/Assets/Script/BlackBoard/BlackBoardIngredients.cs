using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BlackBoardIngredients : MonoBehaviour
{
    [SerializeField] private Ingredient ingredient;
    public Ingredient Ingredient => ingredient;

    private void Update()
    {
        Image image = gameObject.transform.GetChild(0).GetComponent<Image>();
        image.sprite = ingredient.Sprite;
        image.GetComponent<RectTransform>().sizeDelta = new Vector2(ingredient.Sprite.rect.width, ingredient.Sprite.rect.height);
    }
}
