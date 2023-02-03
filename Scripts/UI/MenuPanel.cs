using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton = null;
        [SerializeField] private Button _muteButton = null;
        [SerializeField] private Button _quitButton = null;
 
        private bool _isMuted = false;
        private bool _isPaused = false;
        private Coroutine _pauseCoroutine = null;
        private Coroutine _exitCoroutine = null;

        public event Action OnExitClick;

        private void OnEnable()
        {
            _quitButton.onClick.AddListener(QuitGame);
            _pauseButton.onClick.AddListener(PauseGame);
            _muteButton.onClick.AddListener(Mute);
        }

        private void OnDisable()
        {
            _quitButton.onClick.RemoveListener(QuitGame);
            _pauseButton.onClick.RemoveListener(PauseGame);
            _muteButton.onClick.RemoveListener(Mute);

            if (_pauseCoroutine != null)
                StopCoroutine(_pauseCoroutine);

            if (_exitCoroutine != null)
                StopCoroutine(_exitCoroutine);
        }

        private void QuitGame()
        {
            _exitCoroutine = StartCoroutine(IEExit());
        }

        private void PauseGame()
        {
            if (_isPaused == false)
            {
                Time.timeScale = 0;
                _isPaused = true;
            }
            else
            {
                Time.timeScale = 1;
                _isPaused = false;
            }
        }

        private void Mute()
        {
            if (_isMuted == false)
            {
                AudioController.Mute();
                _isMuted = true;
            }
            else
            {
                AudioController.UnMute();
                _isMuted = false;
            }
        }  

        private IEnumerator IEExit()
        {
            OnExitClick?.Invoke();
            yield return new WaitForSeconds(0.5f);
            Time.timeScale = 0f;
        }
    }
}