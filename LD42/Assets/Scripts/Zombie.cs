using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float speed;

    public float health;

	void Start () {
		
	}
	
	
	void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
	}
}
