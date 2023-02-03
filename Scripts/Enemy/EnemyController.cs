using Spine.Unity;
using UnityEngine;

namespace SnowballFight
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyAttack _enemyAttack = null;
        [SerializeField] private EnemyMove _enemyMove = null;
        [SerializeField] private CharacterAnimation _characterAnimation = null;
        [SerializeField] private SkinChange _skinChange = null;
        [SerializeField] private string _runAnimation = null;
        [SerializeField] private EnemyHit _enemyHit = null;
        [SerializeField] private IMove _move;

        private void Awake()
        {
            _move = GetComponent<IMove>();
        }

        private void Update()
        {
            _move.Move();
        }

        private void OnEnable()
        {
            _enemyAttack.OnThrowSnowball += _characterAnimation.ThrowSnowball;
            _enemyAttack.OnThrowSnowball += _enemyMove.StopMovement;
            _enemyAttack.OnFinishThrowing += RunAnimation;
            _enemyAttack.OnFinishThrowing += _enemyMove.StartMovement;

            _enemyMove.OnMoveIn += _skinChange.ChangeSkin;
            _enemyMove.OnStartMove += _characterAnimation.Run;

            _enemyHit.OnDamage += _enemyMove.MoveOut;
        }

        private void OnDisable()
        {
            _enemyAttack.OnThrowSnowball -= _characterAnimation.ThrowSnowball;
            _enemyAttack.OnThrowSnowball -= _enemyMove.StopMovement;
            _enemyAttack.OnFinishThrowing -= _characterAnimation.Run;
            _enemyAttack.OnFinishThrowing -= _enemyMove.StartMovement;

            _enemyMove.OnMoveIn -= _skinChange.ChangeSkin;
            _enemyMove.OnStartMove -= _characterAnimation.Run;

            _enemyHit.OnDamage -= _enemyMove.MoveOut;
        }

        public void StopSpawn()
        {
            _enemyAttack.StopShoot();
        }

        private void RunAnimation()
        {
            _characterAnimation.SetAnimationName(_runAnimation, true);
        }
    }
}