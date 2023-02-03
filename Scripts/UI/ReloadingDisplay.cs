using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class ReloadingDisplay : MonoBehaviour
    {
        [SerializeField] private Image _fireButton = null;
        [SerializeField] private GameSettings _gameSettings = null;

        private Tween _fillTween = null;

        private void OnDisable()
        {
            if (_fillTween != null)
                _fillTween.Kill();
        }

        public void FillButton()
        {
            _fireButton.fillAmount = 0f;
            _fillTween = _fireButton.DOFillAmount(1f, _gameSettings.PlayerReloadTime).SetEase(Ease.Linear);
        }
    }
}