using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBars : MonoBehaviour {
    //selects which bandwidth your bar wants to be in
    public int bandwidth;
    //where you want the scale/heigh of your bandwidth to begin
    public float startScale;
    //how much you want to multiply the scale of the bandwidth
    public float scaleMultiplier;
    //specifies when buffer is used
    public bool Buffer;
    public Color color;
    private Material material;


    void Start() {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update() {
        //if enabled, it will change the bandwidth utilizing buffer
        if (Buffer) {
            //Y scale will have a value of the bandwidth buffer calculation
            transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.bandBuffer[bandwidth] * scaleMultiplier) + startScale, transform.localScale.z);
            //This will respond to the audio bandwidth buffer scale, intensifying the color of the bar the higher it gets
            Color _colorEmission = new Color(color.r * AudioSpectrum.bandBuffer[bandwidth], color.g * AudioSpectrum.bandBuffer[bandwidth], color.b * AudioSpectrum.bandBuffer[bandwidth], 1);
            material.SetColor("_EmissionColor", _colorEmission);
        }
        //if disabled, it will use the original values from the frequency bandwidth without buffer
        if (!Buffer) {
            //Y scale will have a value of the frequency bandwidth calculation
            transform.localScale = new Vector3(transform.localScale.x, (AudioSpectrum.freqBand[bandwidth] * scaleMultiplier) + startScale, transform.localScale.z);
            //This will respond to the audio bandwidth scale, intensifying the color of the bar the higher it gets
            Color _colorEmission = new Color(color.r * AudioSpectrum.freqBand[bandwidth], color.g * AudioSpectrum.freqBand[bandwidth], color.b * AudioSpectrum.freqBand[bandwidth], 1);
            material.SetColor("_EmissionColor", _colorEmission);
        }
    }
}
