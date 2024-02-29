using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    private static AudioManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void PlayBackgroundMusic(AudioClip clip)
    {
        instance.audioSource.clip = clip;
        instance.audioSource.Play();
    }

    public static void StopBackgroundMusic()
    {
        instance.audioSource.Stop();
    }

    public static void SetVolume(float volume)
    {
        instance.audioSource.volume = volume;
    }
}
