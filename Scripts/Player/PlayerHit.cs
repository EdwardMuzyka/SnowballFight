using System;

namespace SnowballFight
{
    public class PlayerHit : ProjectileHit, IHit
    {
        private ThrowerType _throwerType = ThrowerType.Player;
        public ThrowerType ThrowerType => _throwerType;

        public event Action OnHit;

        public override void Hit()
        {
            base.Hit();
            OnHit?.Invoke();
        }
    }
}