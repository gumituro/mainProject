using UnityEngine;
using UnityEngine.Audio;

public class GlobalAudioController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20f;
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void ToggleMute()
    {
        float currentVolume;
        if (audioMixer.GetFloat("MusicVolume", out currentVolume))
        {
            if (currentVolume <= -79f)
                audioMixer.SetFloat("MusicVolume", 0f);   // Unmute
            else
                audioMixer.SetFloat("MusicVolume", -80f); // Mute
        }
    }
}