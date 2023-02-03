using UnityEngine;

namespace SnowballFight
{
    public abstract class ProjectileHit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem = null;
        [SerializeField] private string _hitSound = null;

        public virtual void Hit()
        {
            AudioController.PlaySound(_hitSound);
            _particleSystem.Play();
        }
    }
}