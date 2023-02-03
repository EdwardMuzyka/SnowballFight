using UnityEngine;

namespace SnowballFight
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerAttack _playerAttack = null;
        [SerializeField] private PlayerMove _playerMove = null;
        [SerializeField] private PlayerReload _playerReload = null;
        [SerializeField] private PlayerHealth _playerHealth = null;
        [SerializeField] private CharacterAnimation _playerAnimation = null;
        [SerializeField] private ReloadingDisplay _reloadingDisplay = null;
        [SerializeField] private LivesDisplay _livesDisplay = null;
        [SerializeField] private StarsDisplay _starsDisplay = null;
        [SerializeField] private PlayerHit _playerHit = null;
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
            _playerAttack.OnShoot += _playerAnimation.ThrowSnowball;
            _playerAttack.OnShoot += _reloadingDisplay.FillButton;
            _playerAttack.OnShoot += _playerReload.Reload;

            _playerMove.OnGameStart += _playerAnimation.Idle;

            _playerReload.OnBeginReload += _playerAttack.StopShoot;
            _playerReload.OnFinishReload += _playerAttack.StartShoot;

            _playerHealth.OnRemoveLife += _livesDisplay.RemoveLifeSprite;
            _playerHealth.OnZeroLivesLeft += _livesDisplay.NoLivesLeft;

            _playerHealth.OnRemoveLife += _starsDisplay.RemoveStar;
            _playerHealth.OnZeroLivesLeft += _starsDisplay.NoStarsLeft;

            _playerHit.OnHit += _playerHealth.RemoveLife;            
        }

        private void OnDisable()
        {
            _playerAttack.OnShoot -= _playerAnimation.ThrowSnowball;
            _playerAttack.OnShoot -= _reloadingDisplay.FillButton;
            _playerAttack.OnShoot -= _playerReload.Reload;

            _playerMove.OnGameStart -= _playerAnimation.Idle;

            _playerReload.OnBeginReload -= _playerAttack.StopShoot;
            _playerReload.OnFinishReload -= _playerAttack.StartShoot;

            _playerHealth.OnRemoveLife -= _livesDisplay.RemoveLifeSprite;
            _playerHealth.OnZeroLivesLeft -= _livesDisplay.NoLivesLeft;

            _playerHealth.OnRemoveLife -= _starsDisplay.RemoveStar;
            _playerHealth.OnZeroLivesLeft -= _starsDisplay.NoStarsLeft;

            _playerHit.OnHit -= _playerHealth.RemoveLife;
        }
    }
}