using System.Collections.Generic;
using UnityEngine;

namespace SnowballFight
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MovePanel[] _panels = null;
        [SerializeField] private LoosePanel _loosePanel = null;
        [SerializeField] private WinPanel _winPanel = null;
        [SerializeField] private PlayerAttack _playerAttack = null;
        [SerializeField] private PlayerHealth _playerHealth = null;
        [SerializeField] private ScoringSystem _scoringSystem = null;
        [SerializeField] private ParticleSystem _particleSystem = null;
        [SerializeField] private CharacterAnimation _playerAnimation = null;
        [SerializeField] private ProjectilePool _projectilePool = null;
        [SerializeField] private EnemyMove[] _enemyMove = null;
        [SerializeField] private CharacterAnimation[] _enemyAnimations = null;
        [SerializeField] private EnemyController[] _enemyControllers = null;

        private void Awake()
        {
            for (int i = 0; i < _panels.Length; i++)
            {
                _panels[i].Show();
            }
        }

        private void OnEnable()
        {
            _playerHealth.OnZeroLivesLeft += _projectilePool.DisableProjectiles;
            _playerHealth.OnZeroLivesLeft += _playerAttack.StopShoot;
            _playerHealth.OnZeroLivesLeft += AudioController.StopSound;
            _playerHealth.OnZeroLivesLeft += _playerAnimation.Idle;
            _playerHealth.OnZeroLivesLeft += _loosePanel.Show;
            for (int i = 0; i < _enemyAnimations.Length; i++)
            {
                _playerHealth.OnZeroLivesLeft += _enemyControllers[i].StopSpawn;
            }
            for (int j = 0; j < _panels.Length; j++)
            {
                _playerHealth.OnZeroLivesLeft += _panels[j].Hide;
            }           
            for (int l = 0; l < _enemyMove.Length; l++)
            {
                _playerHealth.OnZeroLivesLeft += _enemyMove[l].StopMovement;
            }
            for (int m = 0; m < _enemyAnimations.Length; m++)
            {
                _playerHealth.OnZeroLivesLeft += _enemyAnimations[m].Idle;
            }
           
            _scoringSystem.OnMaximumScore += _winPanel.Show;
            _scoringSystem.OnMaximumScore += _projectilePool.DisableProjectiles;
            _scoringSystem.OnMaximumScore += _particleSystem.Play;
            _scoringSystem.OnMaximumScore += _playerAttack.StopShoot;
            _scoringSystem.OnMaximumScore += AudioController.StopSound;
            _scoringSystem.OnMaximumScore += _playerAnimation.Idle;
            for (int i = 0; i < _enemyControllers.Length; i++)
            {
                _scoringSystem.OnMaximumScore += _enemyControllers[i].StopSpawn;
            }
            for (int j = 0; j < _panels.Length; j++)
            {
                _scoringSystem.OnMaximumScore += _panels[j].Hide;
            }            
            for (int l = 0; l < _enemyMove.Length; l++)
            {
                _scoringSystem.OnMaximumScore += _enemyMove[l].StopMovement;
            }
            for (int m = 0; m < _enemyAnimations.Length; m++)
            {
                _scoringSystem.OnMaximumScore += _enemyAnimations[m].Idle;
            }
        }

        private void OnDisable()
        {
            _playerHealth.OnZeroLivesLeft -= _loosePanel.Show;
            _playerHealth.OnZeroLivesLeft -= _projectilePool.DisableProjectiles;
            _playerHealth.OnZeroLivesLeft -= _playerAttack.StopShoot;
            _playerHealth.OnZeroLivesLeft -= AudioController.StopSound;
            _playerHealth.OnZeroLivesLeft -= _playerAnimation.Idle;
            for (int i = 0; i < _enemyControllers.Length; i++)
            {
                _playerHealth.OnZeroLivesLeft -= _enemyControllers[i].StopSpawn;
            }
            for (int j = 0; j < _panels.Length; j++)
            {
                _playerHealth.OnZeroLivesLeft -= _panels[j].Hide;
            }           
            for (int l = 0; l < _enemyMove.Length; l++)
            {
                _playerHealth.OnZeroLivesLeft -= _enemyMove[l].StopMovement;
            }
            for (int m = 0; m < _enemyAnimations.Length; m++)
            {
                _playerHealth.OnZeroLivesLeft -= _enemyAnimations[m].Idle;
            }

            _scoringSystem.OnMaximumScore -= _projectilePool.DisableProjectiles;
            _scoringSystem.OnMaximumScore -= _particleSystem.Play;
            _scoringSystem.OnMaximumScore -= _playerAttack.StopShoot;
            _scoringSystem.OnMaximumScore -= AudioController.StopSound;
            _scoringSystem.OnMaximumScore -= _playerAnimation.Idle;
            _scoringSystem.OnMaximumScore -= _winPanel.Show;
            for (int i = 0; i < _enemyControllers.Length; i++)
            {
                _scoringSystem.OnMaximumScore -= _enemyControllers[i].StopSpawn;
            }
            for (int j = 0; j < _panels.Length; j++)
            {
                _scoringSystem.OnMaximumScore -= _panels[j].Hide;
            }            
            for (int l = 0; l < _enemyMove.Length; l++)
            {
                _scoringSystem.OnMaximumScore -= _enemyMove[l].StopMovement;
            }
            for (int m = 0; m < _enemyAnimations.Length; m++)
            {
                _scoringSystem.OnMaximumScore += _enemyAnimations[m].Idle;
            }
        }
    }
}