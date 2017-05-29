using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform spawnPoin;
    public HeliCopter heli;

    public AudioClip whatHappened;

    private bool reSpawn = false;
    private Transform[] spawnPoints;
    private bool lastToggle = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        spawnPoints = spawnPoin.GetComponentsInChildren<Transform>();
        audioSource = FindAudioSourceByPriority();
        audioSource.clip = whatHappened;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(lastToggle != reSpawn)
        {
            Respawn();
            reSpawn = false;
        }
        else
        {
            lastToggle = reSpawn;
        }
	}

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        Debug.Log("Respawn " + i);
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea()
    {
        heli.Call();    
    }

    public AudioSource FindAudioSourceByPriority()
    {
        AudioSource[] aSource = GetComponents<AudioSource>();
        foreach (AudioSource source in aSource)
        {
            if (source.priority == 1)
            {
                Debug.Log("Audio source found");
                return source;
            }
        }

        throw new UnityException("Audio source = 1 not found");
    }
}
