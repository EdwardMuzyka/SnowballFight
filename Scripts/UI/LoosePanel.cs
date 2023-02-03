using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SnowballFight
{
    public class LoosePanel : MovePanel
    {
        [SerializeField] private Button _mainMenuButton = null;
        [SerializeField] private Button _restartButton = null;
        [SerializeField] private TextMeshProUGUI _finalScore = null;
        [SerializeField] private ScoringSystem _scoringSystem = null;
        
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

        public void FinalScore()
        {
            _finalScore.text = "Your final score is:" + "    " + _scoringSystem.CurrentScore.ToString();
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