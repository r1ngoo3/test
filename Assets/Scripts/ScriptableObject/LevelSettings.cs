using UnityEngine;

[System.Serializable]
public class Level
{
    [SerializeField]
    private int _cardCount;

    [SerializeField]
    private GameCard[] _cardVariants;

    public int CardCount => _cardCount;

    public GameCard[] CardVariants => _cardVariants;
}

[CreateAssetMenu(fileName = "Levels", menuName = "Level/LevelSettings", order = 0)]
public class LevelSettings : ScriptableObject
{
    [SerializeField]
    private Level[] _levels;

    [SerializeField]
    private Color[] _backgroundColors;

    public Level[] Levels => _levels;
    public Color[] BackgroundColors => _backgroundColors;
}
