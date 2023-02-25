using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TutorialTransition
{
    private List<Condition> conditions = new List<Condition>();
    public List<Condition> Conditions => conditions;

    public bool Evaluate(Dictionary<string, int> t)
    {
        if (Conditions.Count == 0) return false;

        foreach(var cond in Conditions)
        {
            if(!cond.Evaluate(t))
            {
                return false;
            }
        }
        return true;
    }
}

public abstract class Condition
{
    public abstract bool Evaluate(Dictionary<string, int> t);
}

public abstract class TutorialSlide
{
    protected TutorialTransition tutorialTransition = new TutorialTransition();
    protected abstract void InitializeCondition();
    public virtual bool EvaluateConditions(Dictionary<string, int> t)
    {
        return tutorialTransition.Evaluate(t);
    }
}
