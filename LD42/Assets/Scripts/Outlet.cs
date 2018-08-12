using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Outlet : MonoBehaviour {

    public bool somethinginit;

    public bool broken;

    public Sprite on, off, el;

    public GameObject button;

    public string key;

    private int ran;

    void Start () {
		
	}

    private int left;

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
        
        if (ran == 1)
        {
            key = "F";
            if (Input.GetKeyDown(KeyCode.F) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 2)
        {
            key = "G";
            if (Input.GetKeyDown(KeyCode.G) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 3)
        {
            key = "B";
            if (Input.GetKeyDown(KeyCode.B) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 4)
        {
            key = "O";
            if (Input.GetKeyDown(KeyCode.O) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 5)
        {
            key = "T";
            if (Input.GetKeyDown(KeyCode.T) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 6)
        {
            key = "V";
            if (Input.GetKeyDown(KeyCode.V) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if (ran == 7)
        {
            key = "Q";
            if (Input.GetKeyDown(KeyCode.Q) && button.activeInHierarchy)
            {
                left -= 1;
                StartCoroutine(anim());
            }
        }
        if(left <= 0)
        {
            broken = false;
            button.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = on;
        }
        button.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = key;
    }

    IEnumerator anim()
    {
        button.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        yield return new WaitForSeconds(0.1f);
        button.transform.localScale = new Vector3(1.5749f, 1.5749f, 1.5749f);
    }
    IEnumerator die()
        {
        if(somethinginit)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
        }    

        if(somethinginit)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = el;
            transform.GetChild(0).transform.parent = null;
            yield return new WaitForSeconds(0.3f);
            gameObject.GetComponent<SpriteRenderer>().sprite = off;          
            broken = true;
            ran = Random.Range(1, 8);
            button.SetActive(true);
            left = 10;
        }
    }
}
