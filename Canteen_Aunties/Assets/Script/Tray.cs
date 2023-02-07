using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : Draggable
{
    [SerializeField] private Ingredient currentIngredient;
    public Ingredient CurrentIngredient => currentIngredient;
    private Plate plate;

    private void Start()
    {
        plate = FindObjectOfType<Plate>();
    }

    public override void OnMouseDown()
    {
        if (!CheckPause())
        {
            IngredientManager.instance.ChangeCursor(CurrentIngredient);
            IngredientManager.instance.ChangeIngredientSpriteOnLatter(CurrentIngredient);
            Latter.instance.AddToLatter(CurrentIngredient);
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

            if (plate.CheckWeightage(CurrentIngredient))
            {
                plate.OnAddIngredient?.Invoke(CurrentIngredient);
            }
            else
            {
                plate.OnPlateFull?.Invoke();
            }

        }
        else
        {
            if (hit.collider.CompareTag("Student"))
            {
                plate.OnGiveDairy?.Invoke(CurrentIngredient);
            }
        }
    }
}
