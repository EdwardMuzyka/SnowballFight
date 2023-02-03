using System;
using UnityEngine;

namespace SnowballFight
{
    public enum ThrowerType { Player, Enemy }

    public class Projectile : MonoBehaviour
    {
        private Rigidbody2D _rigidbody = null;
        private CapsuleCollider2D _collider = null;

        private ThrowerType _throwerType;

        private void Awake()
        {
            _rigidbody =  gameObject.AddComponent<Rigidbody2D>();
            _collider = gameObject.AddComponent<CapsuleCollider2D>();
        }

        private void OnEnable()
        {            
            _collider.isTrigger = true;
        }

        public void PlayerThrow(float speed)
        {
            _throwerType = ThrowerType.Player;
            _rigidbody.velocity = new Vector2(speed * transform.localScale.x, 0f);
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.gravityScale = 0.2f;
        }

        public void EnemyThrow(float speed)
        {
            _throwerType = ThrowerType.Enemy;
            _rigidbody.velocity = new Vector2(speed * transform.localScale.x, 0f);
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IHit target = collision.gameObject.GetComponent<IHit>();
            if (target != null && target.ThrowerType != _throwerType)
            {
                target.Hit();
                gameObject.SetActive(false);
            }
        }
    }
}