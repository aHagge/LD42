using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour {

    public bool somethinginit;

    public bool broken;

    public Sprite on, off;

    void Start () {
		
	}

    private bool fast;

	void FixedUpdate () {
        if (transform.childCount != 0 && !fast)
        {
            somethinginit = true;
            StartCoroutine(die());
            fast = true;

        }
        if (transform.childCount == 0)
        {
            fast = false;
            somethinginit = false;
            StopCoroutine(die());
        }
    }

    IEnumerator die()
        {
        print("start");
        yield return new WaitForSeconds(Random.Range(5,10));

        if(somethinginit)
        {
            print("done");
            gameObject.GetComponent<SpriteRenderer>().sprite = off;
            transform.GetChild(0).transform.parent = null;
            broken = true;
        }
    }
}
