using UnityEngine;
using DG.Tweening;

namespace SnowballFight
{
    public class MovePanel : MonoBehaviour
    {
        [SerializeField] private Vector2 _showPosition = new Vector2();
        [SerializeField] private Vector2 _hidePosition = new Vector2();
        [SerializeField] private RectTransform _rectTransform = null;

        private Tween _moveTween = null;

        private void OnDisable()
        {
            if (_moveTween != null)
                _moveTween.Kill();
        }

        public void Show()
        {
            _moveTween = _rectTransform.DOAnchorPos(_showPosition, 0.5f).SetEase(Ease.Linear);
        }

        public void Hide()
        {
            _moveTween = _rectTransform.DOAnchorPos(_hidePosition, 0.5f).SetEase(Ease.Linear);
        }
    }
}