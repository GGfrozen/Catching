using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    #region Singleton
    public static AudioPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefs.GetFloat(PREFS_MUSIC_VOLUME, 0.5f);
        }
    }
    #endregion

    private AudioSource audioSource;
    private const string PREFS_MUSIC_VOLUME = "MusicVolume";
    public void MusicVolumeChange(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(PREFS_MUSIC_VOLUME, value);
    }
    public float GetMusicVolume()
    {
        return audioSource.volume;
    }
}
