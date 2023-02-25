using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthSlide : TutorialSlide
{
    public class MilkGive : Condition
    {
        public const string DairyGiven = "DairyGiven";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(DairyGiven, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public SixthSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new MilkGive());
}
