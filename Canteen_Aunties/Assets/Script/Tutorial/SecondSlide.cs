using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSlide : TutorialSlide
{
    public class PressedMoveTray : Condition
    {
        public const string MoveTray = "MoveTray";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(MoveTray, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public SecondSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new PressedMoveTray());
}
