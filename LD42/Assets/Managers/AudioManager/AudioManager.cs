using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    public Slider volume;

    private void Start()
    {
        Play("Menu");
    }
    // Use this for initialization

    public AudioMixer am;
    public void setvolume(float volume)
    {
        am.SetFloat("Volume", volume);
    }


    void Awake () {      
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {           
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.outputAudioMixerGroup = am.FindMatchingGroups("Master")[0];
            s.Source.clip = s.Clip;

            s.Source.volume = s.volume;
            s.Source.pitch = s.pitch;
            s.Source.loop = s.loop;
        }
	}

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cant find sound!");
            return;
        }
        s.Source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Cant find sound!");
            return;
        }
        s.Source.Stop();
    }



    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            Play("Story");
            Play("Typing");
            Stop("Menu");                   
        }
        if (level == 2)
        {
            Stop("Story");
            Stop("Typing");
        }
        if (level == 3)
        {
            Stop("Main");
            Play("Garage");
        }
        if (level == 4)
        {
            Play("Main");
            Stop("Garage");
        }
        if (level == 0)
        {
            Play("Menu");
        }
            if (level == 5)
        {
            Stop("Main");
            Play("Fired");
        }
    }
}
