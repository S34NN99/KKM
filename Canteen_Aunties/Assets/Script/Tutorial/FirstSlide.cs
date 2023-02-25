using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSlide : TutorialSlide
{
    public class TutorialStart : Condition
    {
        public const string GameStart = "GameStart";
        public override bool Evaluate(Dictionary<string, int> t)
        {
            t.TryGetValue(GameStart, out int i);
            if (i == 0)
                return false;
            else
                return true;
        }
    }

    public FirstSlide() => InitializeCondition();
    protected override void InitializeCondition() => tutorialTransition.Conditions.Add(new TutorialStart());
}
