using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // Start playing background music
    void Start()
    {
        musicSource.clip = yourMusicClip;
        musicSource.Play();
    }

    // Play sound effect based on event
    public void PlaySFX()
    {
        sfxSource.clip = yourSFXClip;
        sfxSource.Play();
    }
}
