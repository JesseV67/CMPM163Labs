using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorBallsChanger : MonoBehaviour {
    //Duration of each color
    public float speed;
    //What Color 1 will be
    public Color Color1;
    //What Color 2 will be
    public Color Color2;
    //Will control the object's rendering
    Renderer rd;

    // Start is called before the first frame update
    void Start() {
        //lt is now referencing the Light component/script
        rd = GetComponent<Renderer>();
    }

    void Update() {
        //Ping pongs between starting frame (0) to speed.
        //Speed divides itself so the color slowly transitions into the next.
        float t = Mathf.PingPong(Time.time, speed) / speed;
        //Toggles back and forth between Color 1 and Color 2 based on t
        GetComponent<Renderer>().material.color = Color.Lerp(Color1, Color2, t);
    }
}