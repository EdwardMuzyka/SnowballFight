using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class ExitPanel : MovePanel
    {
        [SerializeField] private Button _exitButton = null;
        [SerializeField] private Button _resumeButton = null;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(QuitGame);
            _resumeButton.onClick.AddListener(ResumeGame);
;        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(QuitGame);
            _resumeButton.onClick.RemoveListener(ResumeGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void ResumeGame()
        {
            Time.timeScale = 1f;
            Hide();
        }
    }
}