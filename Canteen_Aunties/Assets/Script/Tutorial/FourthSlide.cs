using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthSlide : TutorialSlide
{
    public class FoodServeOrThrown : Condition
    {
        public const string FoodServeOrThrow = "FoodServeOrThrow";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(FoodServeOrThrow, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public FourthSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new FoodServeOrThrown());
}
