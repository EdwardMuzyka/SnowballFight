using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SnowballFight
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton = null;
        [SerializeField] private Button _resumeButton = null;
        [SerializeField] private MovePanel _movePanel = null;
        
        private void OnEnable()
        {
            _mainMenuButton.onClick.AddListener(ReturnToMainMenu);
            _resumeButton.onClick.AddListener(ResumeGame);
        }

        private void OnDisable()
        {
            _mainMenuButton.onClick.RemoveListener(ReturnToMainMenu);
            _resumeButton.onClick.RemoveListener(ResumeGame);
        }

        private void ReturnToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            AudioController.StopMusic();
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            _movePanel.Hide();
        }
    }
}