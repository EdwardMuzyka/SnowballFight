using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class StarsDisplay : MonoBehaviour
    {
        [SerializeField] private Image[] _stars = null;

        private int _currentStar = 3;

        public void RemoveStar()
        {
            _currentStar--;
            if (_currentStar > 0)
                _stars[_currentStar].enabled = false;
        }

        public void NoStarsLeft()
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                _stars[i].enabled = false;
            }
        }
    }
}