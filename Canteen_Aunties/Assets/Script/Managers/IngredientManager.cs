using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager instance = null;

    [SerializeField] private SpriteRenderer ingredientPlaceholder;
    [SerializeField] private List<Sprite> cursorImages;
    [SerializeField] private Latter latter;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //check which ingredient and which placeholder to change into
    }

    public void ChangeCursor(Ingredient ingredient)
    {
        switch(ingredient.Category)
        {
            case Category.Vege:
                latter.cursorSprite.sprite = cursorImages[2];
                break;

            default:
                latter.cursorSprite.sprite = cursorImages[1];
                break;
        }
    }

    public void ChangeDefaultCursor()
    {
        latter.cursorSprite.sprite = cursorImages[0];
    }

    public void ChangeIngredientSpriteOnLatter(Ingredient ID)
    {
        ingredientPlaceholder.sprite = ID.Sprite;
    }

    public void DropIngredient()
    {
        ingredientPlaceholder.sprite = null;
    }
}
