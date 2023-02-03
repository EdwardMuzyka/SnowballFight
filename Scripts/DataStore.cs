using UnityEngine;

namespace SnowballFight
{
    public static class DataStore
    {
        private const string SOUNDS_VOLUME_KEY = "SOUNDS_VOLUME_KEY";
        private const string MUSIC_VOLUME_KEY = "MUSIC_VOLUME_KEY";

        public static void SaveSoundVolume(float value)
        {
            PlayerPrefs.SetFloat(SOUNDS_VOLUME_KEY, value);
        }

        public static float LoadSoundVolume()
        {
            if (PlayerPrefs.HasKey(SOUNDS_VOLUME_KEY))
                return PlayerPrefs.GetFloat(SOUNDS_VOLUME_KEY);
            else
                return 1f;
        }

        public static void SaveMusicVolume(float value)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
        }

        public static float LoadMusicVolume()
        {
            if (PlayerPrefs.HasKey(MUSIC_VOLUME_KEY))
                return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
            else
                return 1f;
        }
    }
}