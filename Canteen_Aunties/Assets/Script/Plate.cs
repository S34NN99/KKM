using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>();
    private List<Ingredient> ingredientList = new List<Ingredient>();
    private Score score;
    private StudentRequest studentRequest;


    [SerializeField] private List<SpriteRenderer> placeholders;
    [SerializeField] private PyramidCalculator calculator;
    [SerializeField] private Poster poster;
    [SerializeField] private StudentRequestUpdate studentRequestUpdate;
    [SerializeField] private PauseManager pauseManager;

    [SerializeField] private Image studentHand;
    [SerializeField] private GameObject plateFullGO;
    [SerializeField] private Color fullPlateColor;
    [SerializeField] private Text resultText; 


    private int currentWeightage = 0;
    private int maxWeightage = 48;

    public int SuccessfulServingCounter;

    public Action<Ingredient> OnAddIngredient;
    public Action<Ingredient> OnGiveDairy;
    public Action OnPlateFull;
    public Action OnStudentServed;

    private void OnMouseEnter()
    {
        if(!pauseManager.IsPaused)
            animator.SetBool("Boolean", true);
    }

    private void OnMouseExit()
    {
        if (!pauseManager.IsPaused)
            animator.SetBool("Boolean", false);
    }

    private void Start()
    {
        score = new Score();

        OnAddIngredient += AddOntoPlate;
        OnAddIngredient += calculator.AddToCurrentCalculator;
        OnAddIngredient += score.AddScore;


        OnGiveDairy += (ingredient) => 
        {
            studentHand.enabled = true;
            studentHand.sprite = ingredient.Sprite;
            studentHand.GetComponent<RectTransform>().sizeDelta = new Vector2(ingredient.Sprite.rect.width, ingredient.Sprite.rect.height);
        };

        OnGiveDairy += (ingredient) => ingredientList.Add(ingredient);
        OnGiveDairy += calculator.AddToCurrentCalculator;
        OnGiveDairy += score.AddScore;

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

        OnStudentServed += () => studentHand.enabled = false;
        OnStudentServed += () => studentRequest.UpdateRequestRequirement(ingredientList);
        OnStudentServed += studentRequest.UpdateRequest;
        OnStudentServed += () => studentRequest.StudentAnimator.SetTrigger("NextStudent");
        OnStudentServed += studentRequestUpdate.ShowNextStudent;
        OnStudentServed += () => score.UpdateScoreToDatabase(score);
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
            OnStudentServed?.Invoke();
            calculator.OnServePlate?.Invoke();
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

    public void ShowTextResult(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "Plate Served";
        }
    }

    public void ShowTextResultEmpty(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = "Emptied Plate";
        }
    }

    public void ChangeStudentRequest(StudentRequest sr, Image image)
    {
        studentRequest = sr;
        studentHand = image;
    }
}
