using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform _cardParent;

    [SerializeField]
    private GameObject _cardPrefab;

    public void CreateLevel(Sprite[] sprites, int cardCount, int indexRequiredCard, LevelCreator levelCreator, bool bounceEffect)
    {
        if (_cardParent.childCount > 0)
            DestroyLastLevel();

        for(int i = 0; i < cardCount; i++)
        {
            Card newCard = Instantiate(_cardPrefab, _cardParent).GetComponent<Card>();

            newCard.Init(levelCreator, sprites[i], i == indexRequiredCard ? true : false, bounceEffect);
        }
    }

    private void DestroyLastLevel()
    {
        var tempArray = new GameObject[_cardParent.transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = _cardParent.transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        {
            DestroyImmediate(child);
        }
    }
}
