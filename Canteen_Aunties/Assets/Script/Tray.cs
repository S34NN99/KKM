using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tray : Draggable
{
    private Plate plate;
    public Plate Plate => plate;

    [SerializeField] private Ingredient currentIngredient;
    public Ingredient CurrentIngredient => currentIngredient;

    [SerializeField] private Animator _animator;
    public Animator _Animator => _animator;
    
    [SerializeField] private ParticleSystem ps;
    public ParticleSystem PS => ps;

    public Action OnClickTray;

    private void Start()
    {
        plate = FindObjectOfType<Plate>();

        OnClickTray += () => _Animator.SetTrigger("IsClick");
        OnClickTray += () => PS.Play();
    }

    public override void OnMouseDown()
    {
        if (!CheckPause())
        {
            IngredientManager.instance.ChangeCursor(CurrentIngredient);
            IngredientManager.instance.ChangeIngredientSpriteOnLatter(CurrentIngredient);
            Latter.instance.AddToLatter(CurrentIngredient);

            OnClickTray?.Invoke();
        }
    }

    public override void OnMouseUp()
    {
        IngredientManager.instance.DropIngredient();
        IngredientManager.instance.ChangeDefaultCursor();

        if (CheckPause())
        {
            return;
        }

        RaycastHit2D hit = Physics2D.Raycast(Latter.instance.transform.position, -Vector2.up);

        if (hit.collider == null)
        {
            return;
        }

        if (CurrentIngredient.Category != Category.Dairy)
        {
            if (!hit.collider.CompareTag("Plate"))
            {
                return;
            }

            if (Plate.CheckWeightage(CurrentIngredient))
            {
                Plate.OnAddIngredient?.Invoke(CurrentIngredient);
            }
            else
            {
                Plate.OnPlateFull?.Invoke();
            }

        }
        else
        {
            if (hit.collider.CompareTag("Student"))
            {
                Plate.OnGiveDairy?.Invoke(CurrentIngredient);
            }
        }
    }
}
