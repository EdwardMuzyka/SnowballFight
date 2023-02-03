using System;
using UnityEngine;

namespace SnowballFight
{
    public enum LaneType { Left, Medium, Right }

    public class EnemyHit : ProjectileHit, IHit
    {
        [SerializeField] private Collider2D _collider = null;
        [SerializeField] private LaneType _laneType;
        [SerializeField] private GameSettings _gameSettings = null;

        public event Action<int> OnHit;
        public event Action OnDamage;

        private int _score = 0;
        private ThrowerType _throwerType = ThrowerType.Enemy;
        public ThrowerType ThrowerType => _throwerType;

        private void OnEnable()
        {
            if (_laneType == LaneType.Left)
                _score = _gameSettings.LeftLaneScore;
            else if (_laneType == LaneType.Medium)
                _score = _gameSettings.MediumLaneScore;
            else if (_laneType == LaneType.Right)
                _score = _gameSettings.RightLaneScore;
        }

        public override void Hit()
        {
            base.Hit();
            _collider.enabled = false;
            OnHit?.Invoke(_score);
            OnDamage?.Invoke();
        }       
    }
}