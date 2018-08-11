using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour {


    private bool inover;

    public int turretid;

    public Sprite onsprite, offsprite;

    private bool inhand;

	void Start () {
		
	}
	
	
	void Update () {

        if(transform.parent != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = onsprite;
        }
        if (transform.parent == null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = offsprite;

            if (turretid == 1)
            {           
                gamemanager.turreton1 = false;
            }
            if (turretid == 2)
            {
                gamemanager.turreton2 = false;
            }
            if (turretid == 3)
            {
                gamemanager.turreton3 = false;
            }
            if (turretid == 4)
            {
                gamemanager.turreton4 = false;
            }
        }


        Vector3 p = new Vector3();
        Camera c = Camera.main;
        Vector2 mousePos = new Vector2();

        mousePos.x = Input.mousePosition.x;
        mousePos.y = Input.mousePosition.y;

        p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 9));

        if(inover && Input.GetMouseButtonDown(0))
        {
            inhand = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            inhand = false;
            if(transform.parent != null)
            {
                
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - 1);
                if (turretid == 1)
                {
                    gamemanager.turreton1 = true;
                }
                if (turretid == 2)
                {
                    gamemanager.turreton2 = true;
                }
                if (turretid == 3)
                {
                    gamemanager.turreton3 = true;
                }
                if (turretid == 4)
                {
                    gamemanager.turreton4 = true;
                }
            }          
        }
        if (inhand)
        {
            transform.position = p;
        }
                
	}

    private void OnMouseEnter()
    {
        inover = true;
    }

    private void OnMouseExit()
    {     
        inover = false;             
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Outlet" && !col.gameObject.GetComponent<Outlet>().somethinginit && !col.gameObject.GetComponent<Outlet>().broken)
        {
            gameObject.transform.parent = col.gameObject.transform;
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        transform.SetParent(null);
    }

}
