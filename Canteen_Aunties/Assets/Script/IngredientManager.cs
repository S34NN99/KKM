using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    public static IngredientManager instance = null;

    [SerializeField] private SpriteRenderer ingredientPlaceholder;
    [SerializeField] private List<Ingredient> ingredients;


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

    public Ingredient GetIngredientData(Ingredient ingredient)
    {
        foreach (Ingredient ID in ingredients)
        {
            if (ingredient == ID)
            {
                Debug.Log(ID.name);
                return ID;            
            }
        }
        return null;
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
