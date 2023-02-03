using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class FireButton : MonoBehaviour
    {
        [SerializeField] private Button _fireButton = null;
        [SerializeField] private PlayerAttack _playerAttack = null;

        private void OnEnable()
        {
            _fireButton.onClick.AddListener(_playerAttack.Attack);
        }

        private void OnDisable()
        {
            _fireButton.onClick.RemoveListener(_playerAttack.Attack);
        }
    }
}