using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioSpectrum : MonoBehaviour {
    //plays back audio into the game
    private AudioSource audioSource;
    //takes all audio hertz and shortens it into 512 samples
    private float[] samples = new float[512];
    //where to store the 8 frequency bands out of the 512 samples
    public static float[] freqBand = new float[8];
    //reduces shock from frequency bands for smoother visuals
    public static float[] bandBuffer = new float[8];
    //buffer will decrease at a certain speed
    public static float[] bufferDecrease = new float[8];

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    //GetSpectrumData(samples, channel, FFTWindow);
    //This will allow us to convert audio (bass, kick, synth, harmonics, etc.) into samples of frequency/amplitude
    //samples refers to the hertz of audio data from the audiosource that we will use in the program as audio samples
    //channel refers to the left (1) and right (2) channels of the audio source, where 0 refers to both
    //FFTWindow refers to "the accuracy of the algorithm that calculates the spectrum data"
    void GetSpectrumAudioSource(){
        audioSource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
    }

    //Creates 8 different music bars out of the 512 audio samples from the spectrum data
    void MakeFrequencyBands() {
        int count = 0;
        for (int i = 0; i < 8; i++) {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++){
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;
        }
    }

    //adds a buffer to the audio bands where the values will rise and drop smoothly instead of rapid bumps
    void BandBuffer()
    {
        for (int i = 0; i < 8; ++i)
        {
            if (freqBand[i] > bandBuffer[i]) {
                bandBuffer[i] = freqBand[i];
                bufferDecrease[i] = 0.005f;
            }

            if (freqBand[i] < bandBuffer[i]) {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.1f;
            }
        }
    }
}
