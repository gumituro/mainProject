using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightTriggerZone : MonoBehaviour
{
    [Tooltip("2d light")]
    public Light2D lightToControl;

    [Tooltip("which layer")]
    public LayerMask triggeringLayers;
    
    public AudioClip lightOnSound;

    public float targetIntensity = 1.5f;
    public float fadeSpeed = 1f;
    public float holdTime = 2f;

    private bool shouldFadeIn = false;
    private bool shouldFadeOut = false;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (shouldFadeIn)
        {
            lightToControl.intensity += fadeSpeed * Time.deltaTime;
            if (lightToControl.intensity >= targetIntensity)
            {
                lightToControl.intensity = targetIntensity;
                shouldFadeIn = false;
                Invoke(nameof(StartFadeOut), holdTime);
            }
        }

        if (shouldFadeOut)
        {
            lightToControl.intensity -= fadeSpeed * Time.deltaTime;
            if (lightToControl.intensity <= 0f)
            {
                lightToControl.intensity = 0f;
                shouldFadeOut = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & triggeringLayers) != 0)
        {
            Debug.Log("Triggered by: " + other.name);
            shouldFadeIn = true;
            shouldFadeOut = false;
            
            if (lightOnSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(lightOnSound);
            }
        }
    }

    private void StartFadeOut()
    {
        shouldFadeOut = true;
    }
}
