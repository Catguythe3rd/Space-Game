using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] NoPauseSounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // This gives sounds in the AudioManager attributes.
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        } 

        foreach (Sound z in NoPauseSounds)
        {
            z.source = gameObject.AddComponent<AudioSource>();
            z.source.clip = z.clip;

            z.source.volume = z.volume;
            z.source.pitch = z.pitch;
            z.source.loop = z.loop;
        }
    }

    public void Update()
    {   // this allows game sounds to pause.
        if (Menus.GameIsPaused == true)
        {
            foreach (Sound s in sounds)
            {
                s.source.Pause();
            }
        }

        if (Menus.GameIsPaused == false)
        {
            foreach (Sound s in sounds)
            {
                s.source.UnPause();
            }
        }
    }
    
    //Allows sounds to play
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void PlayZ (string name)
    {
        Sound z = Array.Find(NoPauseSounds, sound => sound.name == name);
        if (z == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        z.source.Play();
    }

    //Allows sounds to pause and unpause
    public void Pause (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }

    //Allows sounds to stop
    public void StopS(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void StopZ(string name)
    {
        Sound z = Array.Find(NoPauseSounds, sound => sound.name == name);
        z.source.Stop();
    }


}









//if (Menus.GameIsPaused == true)
// {
//     FindObjectOfType<AudioManager>().Pause("LazerNoise2");
//   }
//   else
//   {
//     FindObjectOfType<AudioManager>().UnPause("LazerNoise2");
//   }
