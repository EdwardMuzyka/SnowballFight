using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace SnowballFight
{
    public class ScoringSystem : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings = null;

        private int _currentScore = 0;

        public int CurrentScore => _currentScore;

        public event Action OnMaximumScore;   

        public void AddScore(int score)
        {
            _currentScore += score;
            if (_currentScore >= _gameSettings.WinningScore)            
                OnMaximumScore?.Invoke();
        }
    }
}