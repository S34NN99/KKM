using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHitBox : MonoBehaviour
{
    [SerializeField] private Sprite buttonEng;
    [SerializeField] private Sprite buttonEngHover;
    [SerializeField] private Sprite buttonBM;
    [SerializeField] private Sprite buttonBMHover;

    private Button button;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.5f;

        ApplyCorrectButtonImage();
    }

    public void ApplyCorrectButtonImage()
    {
        if(!FindObjectOfType<TranslationManager>().IsPlayedInBM)
        {
            image.sprite = buttonEng;

            SpriteState tempstate = button.spriteState;
            tempstate.highlightedSprite = buttonEngHover;
            button.spriteState = tempstate;
        }
        else
        {
            image.sprite = buttonBM;

            SpriteState tempstate = button.spriteState;
            tempstate.highlightedSprite = buttonBMHover;
            button.spriteState = tempstate;
        }
    }
}
