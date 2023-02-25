using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game State Database")]
public class TutorialStateDatabase : ScriptableObject
{
    [SerializeField] private string[] _boolStateNames;
    public string[] BoolStateNames => _boolStateNames;
}
