using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SnowballFight
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton = null;
        [SerializeField] private Button _quitGameButton = null;
        [SerializeField] private Button _setttingsButton = null;
        [SerializeField] private string _music = null;
        [SerializeField] private SettingsPanel _settingsPanel = null;
        //[SerializeField] private AudioManager _audioManager = null;

        private void Start()
        {
            AudioController.Init();
            AudioController.PlayMusic(_music);
            //_audioManager.Init();
            //_audioManager.PlayMusic();
        }

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(StartGame);
            _quitGameButton.onClick.AddListener(QuitGame);
            _setttingsButton.onClick.AddListener(ShowSettings);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(StartGame);
            _quitGameButton.onClick.RemoveListener(QuitGame);
            _setttingsButton.onClick.RemoveListener(ShowSettings);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void ShowSettings()
        {
            _settingsPanel.Show();
        }
    }
}