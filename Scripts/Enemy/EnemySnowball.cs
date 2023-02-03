//using System;
//using UnityEngine;

//namespace SnowballFight
//{
//    public class EnemySnowball : MonoBehaviour
//    {
//        [SerializeField] private Transform _startPosition = null;
//        [SerializeField] private Rigidbody2D _rigidBody = null;
//        [SerializeField] private ParticleSystem _particleSystem = null;

//        public event Action OnHit; 

//        private void OnTriggerEnter2D(Collider2D collision)
//        {
//            PlayerHit target = collision.gameObject.GetComponent<PlayerHit>();
//            if (target != null && target.ThrowerType != ThrowerType.Enemy)
//            {               
//                OnHit?.Invoke();
//                _particleSystem.transform.position = _rigidBody.transform.position;               
//                target.Hit();
//                gameObject.SetActive(false);
//                _rigidBody.transform.position = _startPosition.position;
//            }                
//        }

//        public void DisableEnemySnowball()
//        {
//            gameObject.TryGetComponent<Collider2D>(out Collider2D collider);
//            collider.isTrigger = false;            
//        }
//    }
//}