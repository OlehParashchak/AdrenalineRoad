using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public Sound[] MusicSound, SfxSound;
    public AudioSource MusicSource, SfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadVolumeSettings();
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(MusicSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
        PlayerPrefs.SetFloat(GlobalConstant.MUSIC_VOLUME, volume);
    }

    public void SFXVolume(float volume)
    {
        SfxSource.volume = volume;
        PlayerPrefs.SetFloat(GlobalConstant.SFX_VOLUME, volume);
    }

    private void LoadVolumeSettings()
    {
        if (PlayerPrefs.HasKey(GlobalConstant.MUSIC_VOLUME))
        {
            MusicSource.volume = PlayerPrefs.GetFloat(GlobalConstant.MUSIC_VOLUME);
        }
        else
        {
            MusicSource.volume = 1.0f;
        }

        if (PlayerPrefs.HasKey(GlobalConstant.SFX_VOLUME))
        {
            SfxSource.volume = PlayerPrefs.GetFloat(GlobalConstant.SFX_VOLUME);
        }
        else
        {
            SfxSource.volume = 1.0f;
        }
    }
}