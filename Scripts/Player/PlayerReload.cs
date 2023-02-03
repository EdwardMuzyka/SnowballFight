using DG.Tweening;
using System;
using UnityEngine;

namespace SnowballFight
{
    public class PlayerReload : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings = null;
        [SerializeField] private string _reloadSound = null;

        public event Action OnBeginReload;
        public event Action OnFinishReload;
        
        public void Reload()
        {
            OnBeginReload?.Invoke();
            DOVirtual.DelayedCall(_gameSettings.PlayerReloadTime, () =>
            {
                AudioController.PlaySound(_reloadSound);
                OnFinishReload?.Invoke();
            });
        }
    }
}