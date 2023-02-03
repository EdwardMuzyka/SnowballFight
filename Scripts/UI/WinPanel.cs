using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SnowballFight
{
    public class WinPanel : MovePanel
    {
        [SerializeField] private Button _mainMenuButton = null;
        [SerializeField] private Button _restartButton = null;       

        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(ReturnToMainMenu);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(ReturnToMainMenu);
            _restartButton.onClick.RemoveListener(RestartGame);
        }

        private void ReturnToMainMenu()
        {
            SceneManager.LoadScene(0);
            AudioController.StopMusic();
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(1);
        }        
    }
}