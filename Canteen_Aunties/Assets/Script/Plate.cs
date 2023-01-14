using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Plate : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();
    private List<Ingredient> ingredientList = new List<Ingredient>();
    [SerializeField] private List<SpriteRenderer> placeholders;
    [SerializeField] private PyramidCalculator calculator;
    [SerializeField] private Poster poster;
    [SerializeField] private StudentRequest studentRequest;

    [SerializeField] private GameObject plateFullGO;
    [SerializeField] private Color fullPlateColor;

    private int currentWeightage = 0;
    private int maxWeightage = 48;

    public Action<Ingredient> OnAddIngredient;
    public Action OnPlateFull;

    private void OnMouseEnter()
    {
        animator.SetBool("Boolean", true);
    }

    private void OnMouseExit()
    {
        animator.SetBool("Boolean", false);
    }

    private void Start()
    {
        OnAddIngredient += AddOntoPlate;
        //OnAddIngredient += DatabaseManager.instance.Score.AddScore;
        OnAddIngredient += calculator.AddToCurrentCalculator;

        OnPlateFull += () => plateFullGO.SetActive(true);
        OnPlateFull += () =>
        {
            transform.GetComponent<SpriteRenderer>().color = fullPlateColor;
            foreach (SpriteRenderer sr in placeholders)
            {
                sr.color = fullPlateColor;
            }
        };
        OnPlateFull += () => animator.SetTrigger("PlateFull");
    }

    public void DisablePlateFullAnimation()
    {
        plateFullGO.SetActive(false);
        transform.GetComponent<SpriteRenderer>().color = Color.white;
        foreach (SpriteRenderer sr in placeholders)
        {
            sr.color = Color.white;
        }
    }

    public bool CheckWeightage(Ingredient ingredient)
    {
        return (currentWeightage + ingredient.Weightage) <= maxWeightage;
    }

    public void AddOntoPlate(Ingredient ingredient)
    {
        ingredientList.Add(ingredient);
        placeholders[ingredientList.Count - 1].sprite = ingredient.Sprite;
        currentWeightage += ingredient.Weightage;
    }

    public void ServePlate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("Boolean", false);
            calculator.OnServePlate?.Invoke();
            studentRequest.OnStudentServed?.Invoke();
            //studentRequest.OnNextStudent?.Invoke();
        }
    }

    public void ShowPlate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("Boolean", true);
        }
    }

    public void EmptyPlate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            foreach (SpriteRenderer sr in placeholders)
            {
                sr.sprite = null;
            }

            currentWeightage = 0;
            ingredientList.Clear();
            calculator.ResetWeightage();
            poster.OnUIReset?.Invoke();
        }
    }
}
