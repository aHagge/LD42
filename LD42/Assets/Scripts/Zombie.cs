using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float speed;

    public float health;

    public Animator anim;

    public bool simple, baby, giant;
	void Start () {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

     }

    public BoxCollider2D col;
    private bool gud;
	
	void Update () {
        if (health <= 0 && !gud)
        {
            StartCoroutine(death());
            gud = true;
        }
        if(!gud)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
	}

    IEnumerator death()
    {
        col.enabled = false;
        anim.SetBool("Dead", true);
        yield return new WaitForSeconds(2.5f);
        if(simple)
        {
            gamemanager.simplezombiekilled++;
            print(gamemanager.simplezombiekilled);
        }
        if(baby)
        {
            gamemanager.babyzombiekilled++;
        }
        if(giant)
        {
            gamemanager.giantzombiekilled++;
        }
        Destroy(gameObject);
    }
}
