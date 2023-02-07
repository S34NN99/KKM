using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Stars", menuName = "ScriptableObjects/Stars", order = 1)]
public class Stars : ScriptableObject
{
    [SerializeField] private Sprite starNo;
    public Sprite StarNo => starNo;

    [SerializeField] private Sprite starYes;
    public Sprite StarYes => starYes;
}
