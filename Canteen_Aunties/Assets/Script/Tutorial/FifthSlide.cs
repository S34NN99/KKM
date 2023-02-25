using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthSlide : TutorialSlide
{
    public class FillEverythingExceptDairy : Condition
    {
        public const string FillEverything = "FillEverythingExceptDairy";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(FillEverything, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public FifthSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new FillEverythingExceptDairy());
}
