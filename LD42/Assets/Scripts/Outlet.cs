﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlet : MonoBehaviour {

    public bool somethinginit;


    void Start () {
		
	}
	

	void FixedUpdate () {
        if (transform.childCount != 0)
        {
            somethinginit = true;
        }
        if (transform.childCount == 0)
        {
            somethinginit = false;
        }
    }
}
