using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    [Tooltip("Number of minutes per second that pass")]
    public float minutesPerSecond;

    private Quaternion startRoation;

	// Use this for initialization
	void Start () {
        startRoation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
	}
}
