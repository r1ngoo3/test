using UnityEngine;
using DG.Tweening;
using System;

public class BounceEffect : MonoBehaviour
{
    [SerializeField]
    private float _strenghtShakeLoseBounce;

    [SerializeField]
    private Ease _bounceEasy, _shakeBounceEasy;

    private Vector3 _startScale = Vector3.one;
    private Vector2 _startPosition = Vector3.zero;

    private Tween _shakeBounce;

    public void Bounce(Vector3 startScale, float durationIn, float durationOut, Action callback = null)
    {
        transform.transform.localScale = startScale;

        var sequence = DOTween.Sequence()
            .Append(transform.DOScale(Vector3.zero, durationIn))
            .Append(transform.DOScale(_startScale, durationOut).SetEase(_bounceEasy))
            .OnComplete(() => callback?.Invoke());
    }

    public void ShakeBounce(float duration, Action callback = null)
    {
        _shakeBounce?.Kill();

        RectTransform rect = transform.GetComponent<RectTransform>();
        rect.anchoredPosition = _startPosition;

        _shakeBounce = rect.DOShakeAnchorPos(duration, _strenghtShakeLoseBounce).SetEase(_shakeBounceEasy)
            .OnComplete(() => rect.DOAnchorPos(_startPosition, 0.1f));
    }
}
