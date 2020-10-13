using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Background Audio")]
    public AudioSource backgroundSource;
    public AudioClip backgroundClip;

    [Header("SFX Audio")]
    public AudioSource SFXSource;
    public AudioClip clickClip;
    public AudioClip flickerClip;

    [Header("Audio Delay")]
    public float delay;
    public float minDelay;
    public float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RampUpBackground());
        StartCoroutine(RandomFlicker());
    }

    float RandomDelay()
    {
        return Random.Range(minDelay, maxDelay);
    }
    
    //plays on toggle
    public void PlayClickSFX()
    {
        SFXSource.PlayOneShot(clickClip, .7f);
    }

    //Play random light flicker SFX
    IEnumerator RandomFlicker()
    {
        yield return new WaitForSecondsRealtime(RandomDelay());

        SFXSource.PlayOneShot(flickerClip, .7f);

        StartCoroutine(RandomFlicker());
    }

    IEnumerator RampUpBackground()
    {
        backgroundSource.volume += 0.1f;

        if (backgroundSource.volume >= .6f && backgroundSource.pitch <= 1.4f)
        {
            backgroundSource.pitch += 0.05f;
        }

        if (backgroundSource.volume >= 1f && backgroundSource.pitch >= 1.4f)
        {
            StartCoroutine(SpeedBackground());
            yield break;
        }

        yield return new WaitForSecondsRealtime(RandomDelay());

        StartCoroutine(RampUpBackground());
    }

    IEnumerator SpeedBackground()
    {
        if (backgroundSource.pitch <= 2f)
        {
            backgroundSource.pitch += 0.15f;
            yield return new WaitForSecondsRealtime(.05f);

            StartCoroutine(SpeedBackground());
            yield break;
        }

        yield return new WaitForSecondsRealtime(delay);


        StartCoroutine(SlowBackground());
    }

    IEnumerator SlowBackground()
    {
        if (backgroundSource.pitch >= 0f)
        {
            backgroundSource.pitch -= 0.25f;
            backgroundSource.volume -= 0.05f;
            yield return new WaitForSecondsRealtime(.05f);

            StartCoroutine(SlowBackground());
            yield break;
        }

        backgroundSource.pitch += 0.75f;
        yield return new WaitForSecondsRealtime(.75f);

        StartCoroutine(StopBackground());
    }   
    
    IEnumerator StopBackground()
    {
        if (backgroundSource.volume > 0f)
        {
            backgroundSource.volume -= 0.05f;
            yield return new WaitForSecondsRealtime(.15f);

            StartCoroutine(StopBackground());
            yield break;
        }

        backgroundSource.pitch = 1f;
        backgroundSource.volume = 0f;

        yield return null;

        StartCoroutine(RampUpBackground());
    }
}
