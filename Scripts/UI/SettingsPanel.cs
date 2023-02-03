using UnityEngine;
using UnityEngine.UI;

namespace SnowballFight
{
    public class SettingsPanel : MovePanel
    {
        [SerializeField] private Slider _musicSlider = null;
        [SerializeField] private Slider _soundSlider = null;
        [SerializeField] private Button _closeButton = null;
        [SerializeField] private string _shootSound = null;
        [SerializeField] private string _music = null;
        //[SerializeField] private AudioManager _audioManager = null;

        private void Start()
        {
            _musicSlider.value = 1f;
            _soundSlider.value = 1f;
        }
       
        public void SetMusicVolume(float value)
        {
            //_audioManager.SetMusicVolume(value);
            //_audioManager.StopSound();
            //_audioManager.PlayMusic();
            AudioController.SetMusicVolume(value);
            AudioController.StopMusic();
            AudioController.PlayMusic(_music);
        }

        public void SetSoundVolume(float value)
        {
            AudioController.SetSoundVolume(value);
            AudioController.StopSound();
            AudioController.PlaySound(_shootSound);
        }

        private void OnEnable()
        {
            _musicSlider.onValueChanged.AddListener(SetMusicVolume);
            _soundSlider.onValueChanged.AddListener(SetSoundVolume);
            _closeButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
            _soundSlider.onValueChanged.RemoveListener(SetSoundVolume);
            _closeButton.onClick.RemoveListener(Hide);
        }
    }
}