using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            
            s.Source = gameObject.AddComponent<AudioSource>();
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
        if(level == 0)
        {
            Play("Menu");
        }
        if (level == 1)
        {
            Play("Story");                    
        }
    }
}
