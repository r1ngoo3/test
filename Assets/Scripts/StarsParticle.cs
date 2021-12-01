using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarsParticle : MonoBehaviour
{
    [SerializeField]
    private GameObject _starPrefab;

    [Header("ParticleSettings")]
    [SerializeField]
    private Vector2 _scaleMultyplierMinAndMax;

    [SerializeField]
    private Vector2 _distanceMinAndMax;

    [SerializeField]
    private Vector2 _durationParticleMinAndMax;

    [SerializeField]
    private int _countStars;

    [SerializeField]
    private Ease _moveEase;

    public void ActiveteParticle()
    {
        for (int i = 0; i < _countStars; i++)
        {
            RectTransform newStar = Instantiate(_starPrefab, transform).GetComponent<RectTransform>();
            Image imageNewStar = newStar.GetComponent<Image>();

            newStar.localScale = Vector3.zero;

            Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            float duration = Random.Range(_durationParticleMinAndMax.x, _durationParticleMinAndMax.y);
            float distance = Random.Range(_distanceMinAndMax.x, _distanceMinAndMax.y);
            float scaleMultyplier = Random.Range(_scaleMultyplierMinAndMax.x, _scaleMultyplierMinAndMax.y);

            newStar.DOScale(1f * scaleMultyplier, duration);
            newStar.DOAnchorPos(direction * distance, duration)
                .OnComplete(() => imageNewStar.DOFade(0, 0.5f))
                .OnComplete(() => Destroy(newStar.gameObject));
        }
    }
}
