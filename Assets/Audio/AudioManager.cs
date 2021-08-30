using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Game;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private GameStateMachine gameStateMachine;
    [SerializeField] private Sound[] sounds;

    public Sound[] Sounds { get => sounds; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.Clip;
            sound.AudioSource.loop = sound.IsLooping;
            sound.AudioSource.playOnAwake = false;
        }
    }

    private void Start()
    {
        
    }

    private void PlayAudioSource(string clipName)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == clipName);
        s.AudioSource.Play();
    }
}
