using System;
using UnityEngine;

namespace SnowballFight
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _currentLives = 3;

        public int CurrentLives => _currentLives;

        public event Action OnZeroLivesLeft;
        public event Action OnRemoveLife;

        public void RemoveLife()
        {
            _currentLives--;
            if (_currentLives > 0)
                OnRemoveLife?.Invoke();
            else if (_currentLives == 0)
                OnZeroLivesLeft?.Invoke();
        }
    }
}