using UnityEngine;

namespace SnowballFight
{
    [CreateAssetMenu(menuName ="ScriptableObjects/DifficultyLevel")]
    public class DifficultyLevel : ScriptableObject
    {
        [Header("Speed")]
        [SerializeField] private float _enemySpeed = 0f;
        [SerializeField] private float _playerSpeed = 0f;
        [Header("Scoring")]
        [SerializeField] private int _winningScore = 0;
        [SerializeField] private int _leftLaneScore = 0;
        [SerializeField] private int _mediumLaneScore = 0;
        [SerializeField] private int _rightLaneScore = 0;
        [Header("Reloading")]
        [SerializeField] private float _playerReloadTime = 0f;

        public float EnemySpeed => _enemySpeed;
        public float PlayerSpeed => _playerSpeed;
        public int WinningScore => _winningScore;
        public int LeftLaneScore => _leftLaneScore;
        public int MediumLaneScore => _mediumLaneScore;
        public int RightLaneScore => _rightLaneScore;
        public float PlayerReloadTime => _playerReloadTime;
    }
}