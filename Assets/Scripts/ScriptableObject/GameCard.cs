using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Level/CardData", order = 0)]
public class GameCard : ScriptableObject
{
    [SerializeField]
    private Sprite[] _sprites;

    public Sprite[] Sprites => _sprites;
}
