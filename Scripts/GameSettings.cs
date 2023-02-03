using UnityEngine;

namespace SnowballFight
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private DifficultyLevel _difficultyLevel = null;
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

        private void Awake()
        {
            SetDifficulty();
        }

        public void SetDifficulty()
        {
            _enemySpeed = _difficultyLevel.EnemySpeed;
            _playerSpeed = _difficultyLevel.PlayerSpeed;
            _winningScore = _difficultyLevel.WinningScore;
            _leftLaneScore = _difficultyLevel.LeftLaneScore;
            _mediumLaneScore = _difficultyLevel.MediumLaneScore;
            _rightLaneScore = _difficultyLevel.RightLaneScore;
            _playerReloadTime = _difficultyLevel.PlayerReloadTime;
        }
    }
}