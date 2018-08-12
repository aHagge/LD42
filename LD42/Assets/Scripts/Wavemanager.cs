using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavemanager : MonoBehaviour {


    public Transform[] spawnpoint;

    private int i;
    public Dayly[] Days;

	void Start () {
        
    }

    public void startwave()
    {
        i = 0;
        InvokeRepeating("Spawn", 5f, 105 / Days[gamemanager.day].enemies.Length);
    }
    public void Spawn()
    {
        Instantiate(Days[gamemanager.day].enemies[i], spawnpoint[Random.Range(0, spawnpoint.Length)].position, Quaternion.identity);
        i++;
    }
}
