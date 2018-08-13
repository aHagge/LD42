using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int bullethealth;

    public float speed;

	void Start () {
        speed = gamemanager.bulletspeed;
        bullethealth = gamemanager.bulletpenetration;
        Destroy(gameObject, 10);
	}
	
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(bullethealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Hit");
            Destroy(gameObject);
          
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Zombie")
        {
            bullethealth -= 1;
            col.gameObject.GetComponent<Zombie>().health -= gamemanager.bulletdmg;
        }
        if (col.gameObject.tag == "Zombie2")
        {
            col.gameObject.GetComponent<Zombie>().health -= gamemanager.bulletdmg;
        }
        if (col.gameObject.tag == "Zombie3")
        {
            bullethealth -= 4;
            col.gameObject.GetComponent<Zombie>().health -= gamemanager.bulletdmg;
        }
    }
}
