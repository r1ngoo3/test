using UnityEngine;
using UnityEngine.UI;

public class TextFindElement : MonoBehaviour
{
    [SerializeField]
    private FadeEffect _fadeImage, _fadeText;

    [SerializeField]
    private Image _image;

    [SerializeField]
    private float _fadeDurationIn, _fadeDurationOut;


    public void SetRequestElementSprite(Sprite sprite)
    {
        _fadeText.FadeIn(_fadeDurationIn, () =>
        {
            _fadeText.FadeOut(1, _fadeDurationOut);
        });

        _fadeImage.FadeIn(_fadeDurationIn, () =>
         {
             _image.sprite = sprite;
             _fadeImage.FadeOut(1, _fadeDurationOut);
         });
    }
}
