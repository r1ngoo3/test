using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    private Text _fadeText;
    private Image _fadeImage;

    private Tween _fadeTween;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
        _fadeText = GetComponent<Text>();
    }

    public void FadeIn(float duration, Action callback = null)
    {
        Fade(0f, duration, callback);
    }

    public void FadeOut( float value, float duration, Action callback = null)
    {
        Fade(value, duration, callback);
    }

    private void Fade(float value, float duration, Action callback = null)
    {
        _fadeTween?.Kill();

        if (value == 0f)
        {
            if (_fadeText && _fadeText.color.a == 0)
                duration = 0;
            if (_fadeImage && _fadeImage.color.a == 0)
                duration = 0;
        }

        if (_fadeText)
        {
            _fadeTween = _fadeText.DOFade(value, duration)
            .OnComplete(() => callback?.Invoke());
        }
        else if (_fadeImage)
        {
            _fadeTween = _fadeImage.DOFade(value, duration)
            .OnComplete(() => callback?.Invoke());
        }
        
    }
}
