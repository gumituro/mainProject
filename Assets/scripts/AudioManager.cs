using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] SoundEffects;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySFX(int soundToPlay)
    {
        SoundEffects[soundToPlay].Play();

    }
}
