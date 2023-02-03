using UnityEngine;

namespace SnowballFight
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick = null;
        [SerializeField] private CharacterAnimation _characterAnimation = null;
        [SerializeField] private PlayerHealth _playerHealth = null;
        [SerializeField] private LoosePanel _loosePanel = null;
        [SerializeField] private MenuPanel _menuPanel = null;
        [SerializeField] private ExitPanel _exitPanel = null;
        [SerializeField] private ScoringSystem _scoringSystem = null;
        [SerializeField] private EnemyHit[] _enemyHits = null;
       
        
        private void OnEnable()
        {
            _joystick.OnMove += _characterAnimation.Run;
            _joystick.OnStop += _characterAnimation.Idle;

            _playerHealth.OnZeroLivesLeft += _loosePanel.FinalScore;

            _menuPanel.OnExitClick += _exitPanel.Show;

            for (int i = 0; i < _enemyHits.Length; i++)
            {
                _enemyHits[i].OnHit += _scoringSystem.AddScore;
            }
        }

        private void OnDisable()
        {
            _joystick.OnMove -= _characterAnimation.Run;
            _joystick.OnStop -= _characterAnimation.Idle;

            _playerHealth.OnZeroLivesLeft += _loosePanel.FinalScore;

            _menuPanel.OnExitClick += _exitPanel.Show;

            for (int i = 0; i < _enemyHits.Length; i++)
            {
                _enemyHits[i].OnHit -= _scoringSystem.AddScore;
            }
        }
    }
}