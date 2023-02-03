using DG.Tweening;
using System;
using UnityEngine;

namespace SnowballFight
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private string _shootSound = null;
        [SerializeField] private ProjectilePool _pool = null;
        [SerializeField] private ProgressBar _progressBar = null;       
        [SerializeField] private float _projectileSpeed = 0f;

        private bool _isShooting = false;
        private bool _canShoot = true;
        private float _startSpeed = 0f;

        public bool IsShooting => _isShooting;

        public event Action OnShoot;

        private void OnEnable()
        {
            _startSpeed = _projectileSpeed;
        }
        public void Attack()
        {
            if (_canShoot)
            {
                _isShooting = true;
                _projectileSpeed *= _progressBar.FillImage.fillAmount;
                OnShoot?.Invoke();
                DOVirtual.DelayedCall(1.5f, () =>
                {
                    AudioController.PlaySound(_shootSound);
                    Projectile projectile = _pool.GetProjectile(transform);                    
                    projectile.PlayerThrow(_projectileSpeed);
                    _isShooting = false;
                });
                _projectileSpeed = _startSpeed * _progressBar.FillImage.fillAmount;
            }
        }

        public void StopShoot()
        {
            _canShoot = false;
        }

        public void StartShoot()
        {
            _canShoot = true;
        }        
    }
}