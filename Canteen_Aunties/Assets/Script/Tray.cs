using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : Draggable
{
    [SerializeField] private Ingredient currentIngredient;
    public Ingredient CurrentIngredient => currentIngredient;

    public override void OnMouseDown()
    {
        IngredientManager.instance.ChangeIngredientSpriteOnLatter(CurrentIngredient);
        Latter.instance.AddToLatter(CurrentIngredient);
    }

    public override void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(Latter.instance.transform.position, -Vector2.up);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Plate"))
            {
                Plate plate = hit.collider.GetComponent<Plate>();
                if (plate.CheckWeightage(CurrentIngredient))
                {
                    plate.OnAddIngredient?.Invoke(CurrentIngredient);
                }
                else
                {
                    plate.OnPlateFull?.Invoke();
                }
            }
        }

        IngredientManager.instance.DropIngredient();
    }
}
