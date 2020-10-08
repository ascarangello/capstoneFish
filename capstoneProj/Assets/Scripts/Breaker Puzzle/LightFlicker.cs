using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light light;
    public int min;
    public int max;

    // Start is called before the first frame update
    void Start()
    {
        light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
