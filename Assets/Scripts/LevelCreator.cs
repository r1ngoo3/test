using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    private RestartMenu _restartMenu;

    [SerializeField]
    private TextFindElement _textFindElement;

    [SerializeField]
    private Spawner _spawner;

    [SerializeField]
    private LevelSettings _levels;

    private List<int> _lastRequestCards = new List<int>();

    private int _currentLevelIndex = 0;

    private Level _currentLevel => _levels.Levels[_currentLevelIndex];
    private List<Color> _backgroundColors = new List<Color>();
    private List<int> usedSprites = new List<int>();

    private void Start()
    {
        GenerateLevel();
    }

    public void LevelComplete()
    {
        if (_currentLevelIndex + 1 <= _levels.Levels.Length - 1)
        {
            _currentLevelIndex++;
            GenerateLevel();
        }
        else
            _restartMenu.ActivateMenu();
    }


    public void RestartGame()
    {
        _lastRequestCards.Clear();
        _currentLevelIndex = 0;
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        EventManager.Reset();

        _backgroundColors.Clear();
        _backgroundColors.AddRange(_levels.BackgroundColors);

        int _cardVariant = Random.Range(0, _currentLevel.CardVariants.Length);

        List<Sprite> randomizeSprites = SelectRandomSprites(_currentLevel.CardVariants[_cardVariant].Sprites, _currentLevel.CardCount);

        int indexRequestCard = SelectRequestCard();

        _textFindElement.SetRequestElementSprite(randomizeSprites[indexRequestCard]);

        _spawner.CreateLevel(randomizeSprites.ToArray(), _currentLevel.CardCount, indexRequestCard, this, _currentLevelIndex == 0);
        EventManager.OnGenerateLevel?.Invoke();
    }

    private int SelectRequestCard()
    {
        int index = 0;

        do
        {
            index = Random.Range(0, _currentLevel.CardCount);
        }
        while (_lastRequestCards.Contains(usedSprites[index]));

        _lastRequestCards.Add(usedSprites[index]);
        return index;
    }

    private List<Sprite> SelectRandomSprites(Sprite[] sprites, int countNeedableSprites)
    {
        List<Sprite> allSprites = new List<Sprite>();
        allSprites.AddRange(sprites);
        usedSprites.Clear();

        List<Sprite> needableSprites = new List<Sprite>();

        for(int i = 0; i < countNeedableSprites; i++)
        {
            int randomElement = allSprites.GetRandomIndex(usedSprites.ToArray());
            needableSprites.Add(allSprites[randomElement]);

            usedSprites.Add(randomElement);
        }

        return needableSprites;
    }

    public Color GetRandomBackgroundColor()
    {
        int randomColorIndex = _backgroundColors.GetRandomIndex();

        Color randomColor = _backgroundColors[randomColorIndex];

        _backgroundColors.RemoveAt(randomColorIndex);

        return randomColor;
    }
}
