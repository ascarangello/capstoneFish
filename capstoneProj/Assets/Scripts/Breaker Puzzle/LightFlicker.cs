using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light lightObject;

    public float minTime, maxTime;
    public float minIntensity, maxIntensity;
    private float startIntensity;


    void Awake()
    {
        lightObject = this.GetComponent<Light>();
        startIntensity = lightObject.intensity;
        Restart();
    }

    IEnumerator Flicker()
    {

        yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

        var random = Random.Range(0, 10);

        lightObject.enabled = !lightObject.enabled;

        StartCoroutine(Flicker());
    }

    IEnumerator EditIntensity()
    {

        yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

        lightObject.intensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(EditIntensity());
    }

    public void Stop()
    {
        StopAllCoroutines();
        lightObject.enabled = true;
        lightObject.intensity = startIntensity;
    }

    public void Restart()
    {
        StopAllCoroutines();
        StartCoroutine(Flicker());
        StartCoroutine(EditIntensity());
    }
}
