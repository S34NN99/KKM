﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Reviews", menuName = "ScriptableObjects/Reviews", order = 2)]

public class ReviewsSO : ScriptableObject
{
    [SerializeField] private List<string> twoStarBelowReviews;
    public List<string> TwoStarBelowReviews => twoStarBelowReviews;

    [SerializeField] private List<string> fiveStarReviews;
    public List<string> FiveStarReviews => fiveStarReviews;

    public string RandomizeAllReview()
    {
        List<string> allReviews = new List<string>();
        allReviews = TwoStarBelowReviews.Union(FiveStarReviews).ToList();
        int randomNum = Random.Range(0, allReviews.Count);

        return allReviews[randomNum];
    }

    public string RandomizeReview(List<string> listToRandomize)
    {
        int num = Random.Range(0, listToRandomize.Count);
        return listToRandomize[num];
    }
}
