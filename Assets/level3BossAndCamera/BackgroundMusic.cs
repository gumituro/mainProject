using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    [Header("Audio Settings")]
    public AudioSource musicSource;
    public AudioClip musicClip;
    public AudioMixerGroup soundEffectGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
            return;
        }
        
        if (musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.outputAudioMixerGroup = soundEffectGroup;
            musicSource.Play();
        }
    }
}