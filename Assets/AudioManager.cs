using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] SoundEffects;


    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }
    public void PlaySFX(int SoundToPlay)
    {
        SoundEffects[SoundToPlay].Play();
    }
}
