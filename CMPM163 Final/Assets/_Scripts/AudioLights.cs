using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLights : MonoBehaviour {
    //bandBuffer from AudioSpectrum script will be returned as bandwidth in this script
    public int bandwidth;
    //minimum and maximum intensity of the light when specified
    public float minIntensity, maxIntensity;
    Light lt;

    // Start is called before the first frame update
    void Start() {
        lt = GetComponent<Light> ();
    }

    // Update is called once per frame
    void Update() {
        //Based on the bandwith, this will determine intensity of the light to the song rhythm 
        lt.intensity = (AudioSpectrum.bandBuffer[bandwidth] * (maxIntensity - minIntensity)) + minIntensity;
    }
}