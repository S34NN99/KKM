using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentRequest : MonoBehaviour
{
    private Animator animator => GetComponentInChildren<Animator>();
    public Animator StudentAnimator => animator;
    [SerializeField] private Menu menu;
    [SerializeField] private StatisticTracker tracker;
    [SerializeField] private Image ingredientRequestedImage;
    [SerializeField] private RectTransform ingredientRect;

    private Ingredient currentRequestedIngredient;

    private int successfulServingCounter;
    public int SuccessfulServingCounter => successfulServingCounter;

    private void Start()
    {
        UpdateRequest();
    }
    
    private Ingredient RandomNextStudentRequest()
    {
        int randomNum = UnityEngine.Random.Range(0, menu.TodayMenus.Count);
        Ingredient requestedIngredient = menu.TodayMenus[randomNum];
        return requestedIngredient;
    }

    #region Jump Randomizer
    public void JumpRandomizer()
    {
        float randomNum = UnityEngine.Random.Range(0.0f, 1.0f);
        if (randomNum <= 0.4f)
            StudentAnimator.SetTrigger("IsJumping");
    }
    #endregion

    #region Update Request
    public void UpdateRequest()
    {
        currentRequestedIngredient = RandomNextStudentRequest();
        ingredientRequestedImage.sprite = currentRequestedIngredient.Sprite;
        ingredientRect.sizeDelta = new Vector2(currentRequestedIngredient.Sprite.rect.width, currentRequestedIngredient.Sprite.rect.height);
    }

    private bool CheckRequestRequirement(List<Ingredient> ingredients)
    {
        return ingredients.Contains(currentRequestedIngredient);
    }

    public void UpdateRequestRequirement(List<Ingredient> listOfIngredients)
    {
        if(CheckRequestRequirement(listOfIngredients))
        {
            Debug.Log("Successful");
            successfulServingCounter++;
        }
    }

    #endregion
}
