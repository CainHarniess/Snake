using UnityEngine;
using Assets.Game;

[System.Serializable]
public class Sound
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip clip;
    [SerializeField] private string name;
    [SerializeField] bool isLooping = false;
    public AudioClip Clip { get => clip; }
    public bool IsLooping { get => isLooping; }
    public string Name { get => name; }

    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
}
