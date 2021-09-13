using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Audio_Collection
{
    public string _clipName;
    public AudioClip _clip;

    [Range(0f, 3f)]
    public float _volume = 1f;

    [Range(0.1f, 3f)]
    public float _pitch = 1f;

    public bool _doLoop = false;

    public bool _mute = false;

    [HideInInspector] public AudioSource _source;
}