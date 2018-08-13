using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public bool shooting;

    public Transform shootinghole;

    public GameObject bullet;

    private bool gotit;
	void Start () {
		
	}
	
	
	void Update () {
		if(shooting && !gotit)
        {
            gotit = true;
            StartCoroutine(Shoot());
        }
        if(!shooting)
        {
            gotit = false;
            StopAllCoroutines();
        }      
	}

    IEnumerator Shoot()
    {       
        yield return new WaitForSeconds(gamemanager.turretspeed);
        if(shooting)
        {
            Instantiate(bullet, shootinghole.position, Quaternion.identity);
            StartCoroutine(Shoot());
        }

    }
}
