using UnityEngine;
using UnityEngine.Audio;


[System.Serializable]
public class Sound
{
    public string Name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3.0f)]
    public float pitch;

    [Range(0, 256)]
    public int priority;

    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public bool playOnAwake;

}
