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
        InitializePlate();

        OnClickTray += () => _Animator.SetTrigger("IsClick");
        OnClickTray += () => PS.Play();
    }

    public void InitializePlate()
    {
        plate = FindObjectOfType<Plate>();
    }

    private void PlayIngredientDropAudio()
    {
        switch(CurrentIngredient.SoundEffect)
        {
            case "Dry":
                GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFoodDroppedDry);
                break;

            case "Wet":
                GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFoodDroppedWet);
                break;

            case "Crispy":
                GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFoodDroppedCrispy);
                break;

            case "Porridge":
                GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFoodDroppedPorridge);
                break;
        }
    }

    public override void OnMouseDown()
    {
        if (!CheckPause())
        {
            IngredientManager.instance.ChangeCursor(CurrentIngredient);
            IngredientManager.instance.ChangeIngredientSpriteOnLatter(CurrentIngredient);
            Latter.instance.AddToLatter(CurrentIngredient);

            OnClickTray?.Invoke();
            GeneralEventManager.Instance.BroadcastEvent(AudioManager.OnFoodPickUp);
        }
    }

    public override void OnMouseUp()
    {

        if (CheckPause())
            return;

        if (Plate == null)
            InitializePlate();

        RaycastHit2D hit = Physics2D.Raycast(Latter.instance.transform.position, -Vector2.up);

        if (hit.collider == null)
        {
            return;
        }

        IngredientManager.instance.DropIngredient();
        IngredientManager.instance.ChangeDefaultCursor();
        PlayIngredientDropAudio();

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
                if(Plate.isTutorial)
                {
                    if(FindObjectOfType<TutorialManager>().CheckSlideNumber(5))
                    {
                        Plate.OnGiveDairyTutorial?.Invoke();
                    }
                }

                Plate.OnGiveDairy?.Invoke(CurrentIngredient);
            }
        }
    }
}
