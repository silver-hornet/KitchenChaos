using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    public static MusicManager Instance { get; private set; }

    AudioSource audioSource;
    float volume = 0.3f;

    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0.3f); // The 0.3f is the default value if PLAYER_PREFS_MUSIC_VOLUME is null
        audioSource.volume = volume; // Adding this since the music starts playing straight away
    }

    public void ChangeVolume()
    {
        volume += 0.1f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save(); // Not strictly neccessary, but adding just in case the game crashes while the player is changing the volume settings
    }

    public float GetVolume()
    {
        return volume;
    }
}
