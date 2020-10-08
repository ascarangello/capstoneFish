using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public float min;
    public float max;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();
        Restart();
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSecondsRealtime(Random.Range(min, max));
        light.enabled = !light.enabled;
        StartCoroutine(Flicker());
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    public void Restart()
    {
        StartCoroutine(Flicker());
    }
}
