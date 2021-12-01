using UnityEngine;
using DG.Tweening;

public class RestartMenu : MonoBehaviour
{
    [SerializeField]
    private FadeEffect _fadeBackground;

    [SerializeField]
    private GameObject _btnRestart;

    [SerializeField]
    private LevelCreator _levelCreator;

    [SerializeField]
    private CanvasGroup _loadscreen;

    public void ActivateMenu()
    {
        _fadeBackground.FadeOut(0.5f, 1f, () => 
        {
            _btnRestart.gameObject.SetActive(true);
        });
    }

    public void Restart()
    {
        _btnRestart.gameObject.SetActive(false);
        _fadeBackground.FadeIn(0f);

        DOTween.To(() => _loadscreen.alpha, x => _loadscreen.alpha = x, 1f, 0.5f)
            .OnComplete(() => 
            {
                _levelCreator.RestartGame();

                DOTween.To(() => _loadscreen.alpha, x => _loadscreen.alpha = x, 0f, 0.2f);
            });
    }
}
