using UnityEngine;
using DG.Tweening;

namespace SnowballFight
{
    public class AudioController : MonoBehaviour
    {
        static private AudioSource _sourceSFX = null;
        static private AudioSource _sourceMusic = null;
        static private float _musicVolume = 1f;
        static private float _sfxVolume = 1f;
        static private AudioClip[] _musicClips = null;
        static private AudioClip[] _soundClips = null;

        public static void Init()
        {
            GameObject gameObject = new GameObject("AudioController");
            DontDestroyOnLoad(gameObject);
            _sourceSFX = gameObject.AddComponent<AudioSource>();
            _sourceMusic = gameObject.AddComponent<AudioSource>();
            _musicClips = Resources.LoadAll<AudioClip>("Audio/Music");
            _soundClips = Resources.LoadAll<AudioClip>("Audio/Sound");
        }

        public static AudioClip GetSound(string clipName)
        {
            for (int i = 0; i < _soundClips.Length; i++)
            {
                if (_soundClips[i].name == clipName)
                    return _soundClips[i];
            }
            return null;
        }

        public static AudioClip GetMusic(string clipName)
        {
            for (int i = 0; i < _musicClips.Length; i++)
            {
                if (_musicClips[i].name == clipName)
                    return _musicClips[i];
            }
            return null;
        }

        public static void PlaySound(string name)
        {
            GameObject gameObject = new GameObject("AudioSource");
            DontDestroyOnLoad(gameObject);
            _sourceSFX = gameObject.AddComponent<AudioSource>();
            AudioClip sound = GetSound(name);            
            _sourceSFX.PlayOneShot(sound, _sfxVolume);            
            DOVirtual.DelayedCall(sound.length, () => Destroy(gameObject));
        }       

        public static void PlayMusic(string name)
        {
            _sourceMusic.spatialBlend = 0.5f;
            _sourceMusic.Stop();
            _sourceMusic.clip = GetMusic(name);
            _sourceMusic.volume = _musicVolume;
            _sourceMusic.loop = true;
            _sourceMusic.Play();
        }

        public static void StopSound()
        {
            _sourceSFX.Stop();
        }

        public static void StopMusic()
        {
            _sourceMusic.Stop();
        }

        public static void SetSoundVolume(float volume)
        {
            if (volume > 1)
                volume = 1;
            DataStore.SaveSoundVolume(volume);
            _sfxVolume = DataStore.LoadSoundVolume();
        }

        public static void SetMusicVolume(float volume)
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