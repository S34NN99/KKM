using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdSlide : TutorialSlide
{
    public class FoodDropped : Condition
    {
        public const string FoodDrop = "FoodDrop";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(FoodDrop, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public ThirdSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new FoodDropped());
}
