using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Translation")]
public class Translation : ScriptableObject
{
    [SerializeField] private string englishText;
    public string EnglishText => englishText;

    [SerializeField] private string malayText;
    public string MalayText => malayText;
}
