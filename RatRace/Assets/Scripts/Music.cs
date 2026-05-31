using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.Play();
    }
}