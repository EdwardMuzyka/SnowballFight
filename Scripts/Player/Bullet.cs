using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace SnowballFight
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer = null;
        [SerializeField] private PlayerAttack _playerAttack = null;
        //[SerializeField] private Reloading _reloading = null;
        [SerializeField] private ParticleSystem _particles = null;
        [SerializeField] private Image _fireButton = null;
        [SerializeField] private GameSettings _gameSettings = null;

        private Tween _fillTween = null;

        private void OnEnable()
        {
            _playerAttack.OnShoot += Shoot;
        }

        private void OnDisable()
        {
            _playerAttack.OnShoot -= Shoot;

            if (_fillTween != null)
                _fillTween.Kill();
        }

        private void Shoot()
        {
            _fireButton.fillAmount = 0f;
            _fillTween = _fireButton.DOFillAmount(1f, _gameSettings.PlayerReloadTime).SetEase(Ease.Linear);
            _spriteRenderer.enabled = false;
            _particles.Stop();
            //_reloading.Reload(_gameSettings.PlayerReloadTime);
            DOVirtual.DelayedCall(_gameSettings.PlayerReloadTime, () =>
            {
                _spriteRenderer.enabled = true;
                _particles.Play();
            });
        }
    }
}