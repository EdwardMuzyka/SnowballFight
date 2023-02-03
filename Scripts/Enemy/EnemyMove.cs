using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

namespace SnowballFight
{
    public enum Direction { Up = 1, Down = -1 }

    public class EnemyMove : MonoBehaviour, IMove
    {
        [SerializeField] private Direction _directionType;
        [SerializeField] private Collider2D _collider = null;
        [SerializeField] private GameSettings _gameSettings = null;

        private int _direction = 1;
        private Vector3 _movement = Vector2.zero;
        private Tween _moveTween = null;
        private Coroutine _moveInCoroutine = null;
        private bool _canMove = true;

        public event Action OnMoveIn;
        public event Action OnStartMove;      

        private void Start()
        {
            OnStartMove?.Invoke();
            _direction = (int)_directionType;
        }

        private void OnDisable()
        {
            if (_moveTween != null)
                _moveTween.Kill();

            if (_moveInCoroutine != null)
                StopCoroutine(_moveInCoroutine);
        }

        public void Move()
        {
            if (_canMove == true)
            {
                _movement = new Vector3(0f, 2 * _direction, 0f);
                transform.position += _movement * _gameSettings.EnemySpeed * Time.deltaTime;
                if (transform.position.y >= 3f | transform.position.y <= -5f)
                    ChangeDirection();
            }
        }

        public void MoveOut()
        {
            DOVirtual.DelayedCall(0.5f, () =>
            _moveTween = transform.DOMove(new Vector2(transform.position.x, -8.0f), 0.5f).SetEase(Ease.Linear).OnComplete (() =>
            _moveInCoroutine = StartCoroutine(IEMoveIn())));
        }
        
        private void ChangeDirection()
        {
            _direction *= -1;
        }       

        private IEnumerator IEMoveIn()
        {            
                OnMoveIn?.Invoke();
                yield return new WaitForSeconds(3f);
                _collider.enabled = true;
                _moveTween = transform.DOMove(new Vector2(transform.position.x, -5.0f), 1f).SetEase(Ease.Linear);
                yield return new WaitForSeconds(0.3f);
                Move();
        }

        public void StopMovement()
        {
            _canMove = false;
        }

        public void StartMovement()
        {
            _canMove = true;
        }
    }
}