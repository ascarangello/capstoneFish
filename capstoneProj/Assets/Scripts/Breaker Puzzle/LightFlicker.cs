using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light light;

    public float minTime, maxTime;
    public float minIntensity, maxIntensity;
    private float startIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();
        startIntensity = light.intensity;
        Restart();
    }

    IEnumerator Flicker()
    {

        yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

        var random = Random.Range(0, 10);

        light.enabled = !light.enabled;

        StartCoroutine(Flicker());
    }

    IEnumerator EditIntensity()
    {

        yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));

        light.intensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(EditIntensity());
    }

    public void Stop()
    {
        StopAllCoroutines();
        light.enabled = true;
        light.intensity = startIntensity;
    }

    public void Restart()
    {
        StopAllCoroutines();
        StartCoroutine(Flicker());
        StartCoroutine(EditIntensity());
    }
}
