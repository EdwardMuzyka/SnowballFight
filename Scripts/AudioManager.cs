using UnityEngine;

namespace SnowballFight
{
    [CreateAssetMenu(menuName = "ScriptableObjects/AudioManager")]
    public class AudioManager : ScriptableObject
    {
        [SerializeField] private AudioClip _hitSound = null;
        [SerializeField] private AudioClip _shootSound = null;
        [SerializeField] private AudioClip _reloadSound = null;
        [SerializeField] private AudioClip _menuShootSound = null;
        [SerializeField] private AudioClip _music = null;
        
        private AudioSource _audioSource = null;
        private float _musicVolume = 1f;
        private float _soundVolume = 1f;

        public void Init()
        {
            GameObject gameObject = new GameObject("AudioController");
            DontDestroyOnLoad(gameObject);
            _audioSource = gameObject.AddComponent<AudioSource>();
        }

        private void PlaySound(AudioClip audioClip, float volume)
        {                        
            _audioSource.PlayOneShot(audioClip, volume);
        }

        public void PlayShootClip()
        {
            PlaySound(_shootSound, _soundVolume);
        }
        public void PlayHitClip()
        {
            PlaySound(_hitSound, _soundVolume);
        }
        public void PlayReloadClip()
        {
            PlaySound(_reloadSound, _soundVolume);
        }
        public void PlayMenuShootClip()
        {
            PlaySound(_menuShootSound, _soundVolume);
        }

        public void PlayMusic()
        {
            _audioSource.spatialBlend = 0.5f;
            _audioSource.loop = true;
            PlaySound(_music, _musicVolume);
        }

        public void StopSound()
        {
            _audioSource.Stop();
        }               

        public void SetSoundVolume(float volume)
        {
            if (volume > 1)
                volume = 1;
            DataStore.SaveSoundVolume(volume);
            _soundVolume = DataStore.LoadSoundVolume();
        }

        public void SetMusicVolume(float volume)
        {
            if (volume > 1)
                volume = 1;
            DataStore.SaveMusicVolume(volume);
            _musicVolume = DataStore.LoadMusicVolume();
        }

        public static void Mute()
        {
            AudioListener.pause = true;
        }

        public static void UnMute()
        {
            AudioListener.pause = false;
        }    
    }
}