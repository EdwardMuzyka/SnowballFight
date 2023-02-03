using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class LivesDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _lives = null;

        private int _currentLifeSprite = 3;

        public void RemoveLifeSprite()
        {
            _currentLifeSprite--;
            if (_currentLifeSprite > 0)
                _lives[_currentLifeSprite].enabled = false;            
        }

        public void NoLivesLeft()
        {
            for (int i = 0; i < _lives.Length; i++)
            {
                _lives[i].enabled = false;
            }
        }
    }
}