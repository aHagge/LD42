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
	
	// Update is called once per frame
	void Update () {
		if(shooting && !gotit)
        {
            gotit = true;
            StartCoroutine(Shoot());
        }      
	}

    IEnumerator Shoot()
    {       
        yield return new WaitForSeconds(1);
        if(shooting)
        {
            Instantiate(bullet, shootinghole.position, Quaternion.identity);
            StartCoroutine(Shoot());
        }

    }
}
