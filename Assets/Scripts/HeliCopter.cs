using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliCopter : MonoBehaviour {

    public AudioClip callSound;

    private bool called = false;
    private AudioSource audioSource;

    private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Call()
    {
        if (!called)
        {
            called = true;
            audioSource.clip = callSound;
            audioSource.Play();
            rigidBody.velocity = new Vector3(0, 0, -5f);
        }
    }
}
