using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound _sound in sounds)
        {
            _sound.source = gameObject.AddComponent<AudioSource>();
            _sound.source.clip = _sound.clip;
            _sound.source.volume = _sound.volume;
            _sound.source.pitch = _sound.pitch;
            _sound.source.loop = _sound.loop;
            _sound.source.priority = _sound.priority;
            _sound.source.playOnAwake = _sound.playOnAwake;
        }
    }

    public void Play(string name)
    {
        Sound _sound = Array.Find(sounds, sound => sound.Name == name);
        
        if(_sound == null)
        {
            Debug.LogWarning("Sound" + name + "not found.");
            return;
        }

        if(_sound.source.volume == 0)
        {
            _sound.source.volume = 0.125f;
        }

        _sound.source.Play();
    }
}
