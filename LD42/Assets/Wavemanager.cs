using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavemanager : MonoBehaviour {

    public GameObject simplezombie;
    public GameObject babyzombie;
    public GameObject giantzombie;

    public Transform[] spawnpoint;
    public float spawnspeed;

	void Start () {
        spawnspeed = 5;
        InvokeRepeating("Spawn", 5f, spawnspeed);
    }

    void Spawn()
    {
        Instantiate(simplezombie, spawnpoint[Random.Range(0, spawnpoint.Length)].position, Quaternion.identity);
    }
}
