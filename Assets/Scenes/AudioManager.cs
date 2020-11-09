using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    public AudioMixerGroup mainMixer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mainMixer;
        }
    }

    private void Start()
    {
        Play("MainMenuBGM");
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu" &&
            SceneManager.GetActiveScene().name != "ChooseLevel")
        {
            Debug.Log(SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
    }

    public void Play(string snd)
    {
        Sound s = Array.Find(sounds, sound => sound.name == snd);
        if (s == null)
        {
            Debug.LogWarning("waring " + snd + " is not defined");
            return;
        }
        s.source.Play();
    }
}
