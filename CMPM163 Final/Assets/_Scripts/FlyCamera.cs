using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FlyCamera : MonoBehaviour {
    public float MouseSensitivity;
    private float rotationX = 0.0f;
    private float rotationY = -45.0f;
    Rigidbody rb;
    public float thrust;
    // Start is called before the first frame update
    void Start() {
        //Gives the camera its collision detection
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update() {
        //Camera's mouse movement will be based on the mouse's X/Y input multiplied by the mouse's sensitivity
        rotationX += Input.GetAxis("Mouse X") * MouseSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * MouseSensitivity;

        //Based on camera sensitivity, local transforms will rotate the X/Y angles in the up and left directions
        transform.rotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.rotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        //If you press the UpArrow keycode OR W keycode, forward force will be applied multiplied by the number of thrust given.
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            rb.AddForce(transform.forward * thrust);
        }
        //If you press the DownArrow keycode OR S keycode, negative forward force will be applied multiplied by the number of thrust given.
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            rb.AddForce(-transform.forward * thrust);
        }
        //If you press the RightArrow keycode OR D keycode, right force will be applied multiplied by the number of thrust given.
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            rb.AddForce(transform.right * thrust);
        }
        //If you press the LeftArrow keycode OR A keycode, right force will be applied multiplied by the number of thrust given.
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            rb.AddForce(-transform.right * thrust);
        }
        //If you press the Space keycode, up force will be applied multiplied by the number of thrust given.
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(transform.up * thrust);
        }
    }
}