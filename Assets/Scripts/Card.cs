using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private StarsParticle _starsParticle;

    [SerializeField]
    private Image _image, _background;

    [SerializeField]
    private BounceEffect _cardBounce, _cardElementBounce;

    private LevelCreator _levelCreator;
    private bool _isRequestCard = false;

    private bool _lockInput = true;

    public void Init(LevelCreator levelCreator, Sprite cardSprite, bool isRequestCard, bool bounceEffect)
    {
        _levelCreator = levelCreator;
        _image.sprite = cardSprite;
        _isRequestCard = isRequestCard;

        _background.color = _levelCreator.GetRandomBackgroundColor();

        EventManager.OnGenerateLevel.AddListener(() => LockInput(false));
        EventManager.OnClickRequestButton.AddListener(() => LockInput(true));

        if (bounceEffect)
            _cardBounce.Bounce(Vector3.zero, 0f, 1f);
    }

    public void SelectCard()
    {
        if (_lockInput)
            return;

        if(_isRequestCard)
        {
            EventManager.OnClickRequestButton?.Invoke();
            _starsParticle.ActiveteParticle();
            _cardElementBounce.Bounce(Vector3.one, 0.3f, 1f, Win);
        }
        else
        {
            _cardElementBounce.ShakeBounce(1f);
        }
    }

    private void LockInput(bool lockInput)
    {
        _lockInput = lockInput;
    }

    private void Win()
    {
        _levelCreator.LevelComplete();
    }
}
