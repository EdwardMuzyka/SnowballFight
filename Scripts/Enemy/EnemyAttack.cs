using UnityEngine;
using DG.Tweening;
using System.Collections;
using System;

namespace SnowballFight
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _projectileSpeed = 0f;        
        [SerializeField] private ProjectilePool _pool = null;
                
        private Coroutine _reloadingCoroutine = null;
        private bool _canAttack = true;

        public event Action OnThrowSnowball;
        public event Action OnFinishThrowing;

        private void Start()
        {
            int attackTime = UnityEngine.Random.Range(2, 5);
            DOVirtual.DelayedCall(attackTime, () => Attack());
        }               

        private void OnDisable()
        {
            if (_reloadingCoroutine != null)
                StopCoroutine(_reloadingCoroutine);
        }        

        public void Attack()
        {
            if (_canAttack == true)
            {
                OnThrowSnowball?.Invoke();
                DOVirtual.DelayedCall(1.5f, () =>
                {
                    Projectile projectile = _pool.GetProjectile(transform);                    
                    projectile.EnemyThrow(-_projectileSpeed);
                    OnFinishThrowing?.Invoke();
                });
                _reloadingCoroutine = StartCoroutine(IEReload());
            }
        }

        public void StopShoot()
        {
            _canAttack = false;
        }

        private IEnumerator IEReload()
        {
            float delay = UnityEngine.Random.Range(3f, 7f);
            yield return new WaitForSeconds(delay);                      
            Attack();            
        }
    }
}