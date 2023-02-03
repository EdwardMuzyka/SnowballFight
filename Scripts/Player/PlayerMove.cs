using System;
using UnityEngine;

namespace SnowballFight
{
    public class PlayerMove : MonoBehaviour, IMove
    {
        [SerializeField] private GameSettings _gameSettings = null;
        [SerializeField] private Joystick _joystick = null;
        
        private float _upBound = 3.2f;
        private float _downBound = -5.1f;       
        private float _move = 0f;

        public event Action OnGameStart;        

        private void Start()
        {
            OnGameStart?.Invoke();
        }        

        public void Move()
        {
            _move = _joystick.Vertical();
            transform.Translate(transform.up * _move * _gameSettings.PlayerSpeed * Time.deltaTime);

            if (transform.position.y >= _upBound)
                transform.position = new Vector3(transform.position.x, _upBound, transform.position.z);
            else if (transform.position.y <= _downBound)
                transform.position = new Vector3(transform.position.x, _downBound, transform.position.z);
        }
    }
}