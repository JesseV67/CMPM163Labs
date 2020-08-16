using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class ColorLightsChanger : MonoBehaviour {
    //Duration of each color
    public float speed;
    //What Color 1 will be
    public Color Color1;
    //What Color 2 will be
    public Color Color2;
    //Will control the object's lightings
    Light lt;

    // Update is called once per frame
    void Start() {
        //lt is now referencing the Light component/script
        lt = GetComponent<Light>();
    }

    void Update() {
        //Ping pongs between starting frame (0) to speed.
        //Speed divides itself so the color slowly transitions into the next.
        float t = Mathf.PingPong(Time.time, speed) / speed;
        //Toggles back and forth between Color 1 and Color 2 based on t
        lt.color = Color.Lerp(Color1, Color2, t);
    }
}
