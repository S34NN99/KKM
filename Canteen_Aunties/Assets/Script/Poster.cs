using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poster : MonoBehaviour
{
    [SerializeField] private List<Slider> pyramidColumnsSlider;

    public Action<Category, float> OnUIUpdate;
    public Action OnUIReset;

    private float currentVelocity;

    private void Start()
    {
        OnUIUpdate += (Category cat, float value) =>
        {
            StartCoroutine(AnimateSliderOverTime(pyramidColumnsSlider[(int)cat], value, 0.5f));
            pyramidColumnsSlider[(int)cat].GetComponentInChildren<Image>().color = DetermineColor(value, cat);
        };

        OnUIReset += () =>
        {
            foreach (Slider slider in pyramidColumnsSlider)
            {
                slider.value = 0;
            }
        };
    }

    private Color DetermineColor(float value, Category cat)
    {
        if(cat == Category.OilsAndFats)
        {
            if (value <= 1.5f)
                return Color.green;

            if (value >= 2f)
                return Color.red;
        }

        if (value == 1)
            return Color.green;
        else if (value > 1)
            return Color.red;
        else
            return Color.yellow;
    }

    private IEnumerator AnimateSliderOverTime(Slider slider, float target, float seconds)
    {
        float animationTime = 0f;
        float currentValue = slider.value;
        while(animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(currentValue, target, lerpValue);
            yield return null;
        }
    }
}
